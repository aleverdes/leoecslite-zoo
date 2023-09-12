using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.EcsLite;

namespace AffenCode
{
    public sealed class EcsInjector
    {
        private readonly Dictionary<Type, object> _injectedObjects = new();
        
        private readonly Dictionary<EcsWorld, Dictionary<Type, object>> _poolsCache = new Dictionary<EcsWorld, Dictionary<Type, object>>();

        public EcsInjector AddInjectionObject(object injectionObject)
        {
            _injectedObjects.Add(injectionObject.GetType(), injectionObject);
            return this;
        }
        
        public EcsInjector AddInjectionObject<T>(object injectionObject)
        {
            _injectedObjects.Add(typeof(T), injectionObject);
            return this;
        }
        
        public EcsInjector AddInjectionObject(object injectionObject, Type type)
        {
            if (!type.IsInstanceOfType(injectionObject))
            {
                throw new Exception($"Can't add object {injectionObject} to injection-list because object's type {injectionObject.GetType()} isn't assignable from {type}");
            }
            
            _injectedObjects.Add(type, injectionObject);
            return this;
        }

        public EcsInjector RemoveInjectionObject(Type injectionType)
        {
            _injectedObjects.Remove(injectionType);
            return this;
        }

        public EcsInjector RemoveInjectionObject<T>()
        {
            _injectedObjects.Remove(typeof(T));
            return this;
        }

        public Dictionary<Type, object> GetInjectedObjects()
        {
            return _injectedObjects;
        }

        public void ExecuteInjection(IEcsSystems ecsSystems)
        {
            Inject(ecsSystems, ecsSystems.GetWorld(), typeof(EcsWorld));
            
            foreach (var (injectionType, injectionObject) in _injectedObjects)
            {
                Inject(ecsSystems, injectionObject, injectionType);
            }

            InjectPools(ecsSystems);
        }


        private IEcsSystems InjectPools(IEcsSystems ecsSystems)
        {
            return InjectPools(ecsSystems, ecsSystems.GetWorld());
        }

        public IEcsSystems InjectPools(IEcsSystems ecsSystems, EcsWorld world)
        {
            if (world == null)
            {
                throw new Exception("For ECS-pool injection required the ECS World");
            }

            if (!_poolsCache.TryGetValue(world, out var poolsByGenericType))
            {
                poolsByGenericType = new Dictionary<Type, object>();
                _poolsCache.Add(world, poolsByGenericType);
            }

            var allSystems = ecsSystems.GetAllSystems();
            
            var getPoolMethod = typeof(EcsWorld).GetMethod(nameof(EcsWorld.GetPool));

            foreach (var system in allSystems)
            {
                var systemType = system.GetType();
                var systemFields = systemType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                foreach (var systemField in systemFields)
                {
                    if (!typeof(IEcsPool).IsAssignableFrom(systemField.FieldType))
                    {
                        continue;   
                    }

                    var poolType = systemField.FieldType.GetGenericArguments().FirstOrDefault();

                    if (!poolsByGenericType.TryGetValue(poolType, out var pool))
                    {
                        var getTypedPoolMethod = getPoolMethod.MakeGenericMethod(poolType);
                        pool = getTypedPoolMethod.Invoke(world, null);
                        poolsByGenericType.Add(poolType, pool);
                        systemField.SetValue(system, pool);
                    }
                    else
                    {
                        systemField.SetValue(system, pool);
                    }
                }
            }
            
            return ecsSystems;
        }
        
        public void InjectPools(object obj, EcsWorld world)
        {
            if (world == null)
            {
                throw new Exception("For ECS-pool injection required the ECS World");
            }

            if (!_poolsCache.TryGetValue(world, out var poolsByGenericType))
            {
                poolsByGenericType = new Dictionary<Type, object>();
                _poolsCache.Add(world, poolsByGenericType);
            }

            var getPoolMethod = typeof(EcsWorld).GetMethod(nameof(EcsWorld.GetPool));

            var systemType = obj.GetType();
            var systemFields = systemType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var systemField in systemFields)
            {
                if (!typeof(IEcsPool).IsAssignableFrom(systemField.FieldType))
                {
                    continue;   
                }

                var poolType = systemField.FieldType.GetGenericArguments().FirstOrDefault();

                if (!poolsByGenericType.TryGetValue(poolType, out var pool))
                {
                    var getTypedPoolMethod = getPoolMethod.MakeGenericMethod(poolType);
                    pool = getTypedPoolMethod.Invoke(world, null);
                    poolsByGenericType.Add(poolType, pool);
                    systemField.SetValue(obj, pool);
                }
                else
                {
                    systemField.SetValue(obj, pool);
                }
            }
        }
        
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

        public static object Inject(object obj, object injectedObject)
        {
            return Inject(obj, injectedObject, injectedObject.GetType());
        }

        public static object Inject(object obj, object injectedObject, Type[] injectionTypes)
        {
            foreach (var injectionType in injectionTypes)
            {
                Inject(obj, injectedObject, injectionType);
            }

            return obj;
        }

        public static object Inject(object obj, object injectedObject, Type injectionType)
        {
            var systemType = obj.GetType();
            var systemFields = systemType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var requiredField = systemFields.FirstOrDefault(x => x.FieldType == injectionType);
            if (requiredField != null)
            {
                requiredField.SetValue(obj, injectedObject);
            }
            
            return obj;
        }
    }
}