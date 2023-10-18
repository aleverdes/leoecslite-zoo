using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class EcsInjection
    {
        private const BindingFlags PrivateInstanceFlags = BindingFlags.NonPublic | BindingFlags.Instance; 
        
        private static readonly Dictionary<object, HashSet<Type>> _processedObjects = new();
        
        private static readonly Dictionary<Type, FieldInfo[]> _fieldsByType = new();
        
        private static MethodInfo _getEcsPoolMethod;
        private static readonly Dictionary<EcsWorld, Dictionary<Type, object>> _poolsCache = new();

        private static MethodInfo _incEcsMaskMethod;
        private static MethodInfo _excEcsMaskMethod;
        private static MethodInfo _endEcsMaskMethod;
        private static readonly Dictionary<Type, MethodInfo> _incEcsMaskGenericMethods = new();
        private static readonly Dictionary<Type, MethodInfo> _excEcsMaskGenericMethods = new();
        
        public static IEcsSystems Inject(IEcsSystems ecsSystems, object injectedObject)
        {
            return Inject(ecsSystems, injectedObject, injectedObject.GetType());
        }

        public static IEcsSystems Inject(IEcsSystems ecsSystems, object injectedObject, Type injectionType)
        {
            var allSystems = ecsSystems.GetAllSystems();

            foreach (var system in allSystems)
            {
                Inject(system, injectedObject, injectionType);
            }
            
            return ecsSystems;
        }

        public static object Inject(object target, object injectedObject)
        {
            return Inject(target, injectedObject, injectedObject.GetType());
        }

        public static object Inject(object target, object injectedObject, Type[] injectionTypes)
        {
            var fields = GetFields(target.GetType());

            foreach (var field in fields)
            {
                if (injectionTypes.Any(injectionType => injectionType == field.FieldType))
                {
                    field.SetValue(target, injectedObject);
                }
            }

            return target;
        }

        public static object Inject(object target, object injectedObject, Type injectionType)
        {
            var fields = GetFields(target.GetType());
            
            var requiredField = fields.FirstOrDefault(x => x.FieldType == injectionType);
            if (requiredField != null)
            {
                requiredField.SetValue(target, injectedObject);
            }
            
            return target;
        }

        public static IEcsSystems InjectPools(IEcsSystems ecsSystems, EcsWorld world)
        {
            if (world == null)
            {
                throw new Exception("For ECS-pool injection required the ECS World");
            }

            var allSystems = ecsSystems.GetAllSystems();

            foreach (var system in allSystems)
            {
                InjectPools(system, world);
            }
            
            return ecsSystems;
        }

        public static object InjectPools(object target, EcsWorld world)
        {
            if (world == null)
            {
                throw new Exception("For ECS-pool injection required the ECS World");
            }
            
            var fields = GetFields(target.GetType());

            foreach (var field in fields)
            {
                if (!typeof(IEcsPool).IsAssignableFrom(field.FieldType))
                {
                    continue;   
                }
                
                var poolType = field.FieldType.GetGenericArguments().First();
                field.SetValue(target, GetEcsPool(world, poolType));
            }

            return target;
        }

        private static MethodInfo GetEcsPoolGetMethod()
        {
            if (_getEcsPoolMethod == null)
            {
                _getEcsPoolMethod = typeof(EcsWorld).GetMethod(nameof(EcsWorld.GetPool));
            }

            return _getEcsPoolMethod;
        }

        private static object GetEcsPool(EcsWorld ecsWorld, Type poolType)
        {
            if (!TryGetEcsPool(ecsWorld, poolType, out var pool))
            {
                var getTypedPoolMethod = GetEcsPoolGetMethod().MakeGenericMethod(poolType);
                pool = getTypedPoolMethod.Invoke(ecsWorld, null);
                CacheEcsPool(ecsWorld, poolType, pool);
            }

            return pool;
        }

        private static void CacheEcsPool(EcsWorld ecsWorld, Type poolType, object ecsPool)
        {
            GetEcsPoolCache(ecsWorld).Add(poolType, ecsPool);
        }
        
        private static bool TryGetEcsPool(EcsWorld ecsWorld, Type poolType, out object ecsPool)
        {
            return GetEcsPoolCache(ecsWorld).TryGetValue(poolType, out ecsPool);
        }

        private static Dictionary<Type, object> GetEcsPoolCache(EcsWorld ecsWorld)
        {
            if (!_poolsCache.TryGetValue(ecsWorld, out var poolsByGenericType))
            {
                poolsByGenericType = new Dictionary<Type, object>();
                _poolsCache.Add(ecsWorld, poolsByGenericType);
            }

            return poolsByGenericType;
        }

        private static FieldInfo[] GetFields(Type type)
        {
            if (!TryGetFields(type, out var fields))
            {
                fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                CacheFields(type, fields);
            }

            return fields;
        }

        private static void CacheFields(Type type, FieldInfo[] fields)
        {
            _fieldsByType[type] = fields;
        }

        private static bool TryGetFields(Type type, out FieldInfo[] fields)
        {
            return _fieldsByType.TryGetValue(type, out fields);
        }

        private static bool CheckObjectForProcessed(object targetObject, Type injectionType)
        {
            if (!_processedObjects.TryGetValue(targetObject, out var injectedTypes))
            {
                _processedObjects[targetObject] = new HashSet<Type>();
                return false;
            }

            return injectedTypes.Contains(injectionType);
        }

        private static void SetObjectAsProcessed(object targetObject, Type injectionType)
        {
            if (!_processedObjects.TryGetValue(targetObject, out var injectedTypes))
            {
                _processedObjects[targetObject] = new HashSet<Type>();
                injectedTypes = _processedObjects[targetObject];
            }

            injectedTypes.Add(injectionType);
        }
        
        public static IEcsSystems InjectQueries(IEcsSystems ecsSystems, EcsWorld world)
        {
            if (world == null)
            {
                throw new Exception("For ECS-pool injection required the ECS World");
            }

            var allSystems = ecsSystems.GetAllSystems();

            foreach (var system in allSystems)
            {
                InjectQueries(system, world);
            }
            
            return ecsSystems;
        }
        
        public static object InjectQueries(object target, EcsWorld world)
        {
            if (world == null)
            {
                throw new Exception("For ECS-queries injection required the ECS World");
            }
            
            var fields = GetFields(target.GetType());

            _incEcsMaskMethod ??= typeof(EcsWorld.Mask).GetMethod("Inc");
            _excEcsMaskMethod ??= typeof(EcsWorld.Mask).GetMethod("Exc");
            _endEcsMaskMethod ??= typeof(EcsWorld.Mask).GetMethod("End");

            foreach (var field in fields)
            {
                if (!field.FieldType.IsGenericType)
                {
                    continue;
                }

                var isIncludeOnly = field.FieldType.GetGenericTypeDefinition() == typeof(EcsQuery<>); 
                var isExcludeOnly = field.FieldType.GetGenericTypeDefinition() == typeof(EcsQuery<>.Exc<>);
                var isIncludeAndExclude = field.FieldType.GetGenericTypeDefinition() == typeof(EcsQuery.Exc<>);

                if (isIncludeOnly)
                {
                    var genericTypes = field.FieldType.GetGenericArguments();
                    
                    var mask = CreateMask(world);
                    foreach (var includeType in genericTypes)
                    {
                        if (!_incEcsMaskGenericMethods.TryGetValue(includeType, out var incMethod))
                        {
                            incMethod = _incEcsMaskMethod.MakeGenericMethod(includeType);
                            _incEcsMaskGenericMethods.Add(includeType, incMethod);
                        }

                        mask = incMethod.Invoke(mask, null);
                    }
                    
                    var query = CreateQuery(field.FieldType, mask);
                    field.SetValue(target, query);
                }
                else if (isExcludeOnly)
                {
                    var genericTypes = field.FieldType.GetGenericArguments();
                    
                    var mask = CreateMask(world);
                    foreach (var excludeType in genericTypes)
                    {
                        if (!_excEcsMaskGenericMethods.TryGetValue(excludeType, out var excMethod))
                        {
                            excMethod = _excEcsMaskMethod.MakeGenericMethod(excludeType);
                            _excEcsMaskGenericMethods.Add(excludeType, excMethod);
                        }

                        mask = excMethod.Invoke(mask, null);
                    }
                    
                    var query = CreateQuery(field.FieldType, mask);
                    field.SetValue(target, query);
                }
                else if (isIncludeAndExclude)
                {
                    var genericTypes = field.FieldType.GetGenericArguments();
                    var includeTypesCount = field.FieldType.DeclaringType.GetGenericArguments().Length;

                    var mask = CreateMask(world);

                    for (var i = 0; i < genericTypes.Length; i++)
                    {
                        var type = genericTypes[i];
                        if (i < includeTypesCount)
                        {
                            if (!_incEcsMaskGenericMethods.TryGetValue(type, out var incMethod))
                            {
                                incMethod = _incEcsMaskMethod.MakeGenericMethod(type);
                                _incEcsMaskGenericMethods.Add(type, incMethod);
                            }

                            mask = incMethod.Invoke(mask, null);
                        }
                        else
                        {
                            if (!_excEcsMaskGenericMethods.TryGetValue(type, out var excMethod))
                            {
                                excMethod = _excEcsMaskMethod.MakeGenericMethod(type);
                                _excEcsMaskGenericMethods.Add(type, excMethod);
                            }

                            mask = excMethod.Invoke(mask, null);
                        }
                    }

                    var query = CreateQuery(field.FieldType, mask);
                    field.SetValue(target, query);
                }
            }

            return target;
        }
        
        private static object CreateMask(EcsWorld world)
        {
            return Activator.CreateInstance(typeof(EcsWorld.Mask), PrivateInstanceFlags, null, new object[] {world}, null);
        }

        private static object CreateQuery(Type queryType, object mask)
        {
            var filter = _endEcsMaskMethod.Invoke(mask, new object[]{512});
            var query = Activator.CreateInstance(queryType);
                    
            var queryFilterField = queryType.GetField("_filter", PrivateInstanceFlags);
            queryFilterField.SetValue(query, filter);

            return query;
        }
    }
}