using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.EcsLite;

namespace AffenCode
{
    public static class EcsInjection
    {
        private static MethodInfo _getEcsPoolMethod;
        
        private static readonly Dictionary<EcsWorld, Dictionary<Type, object>> _poolsCache = new Dictionary<EcsWorld, Dictionary<Type, object>>();
        private static readonly Dictionary<Type, FieldInfo[]> _fieldsByType = new Dictionary<Type, FieldInfo[]>();

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
                field.SetValue(world, GetEcsPool(world, poolType));
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
    }
}