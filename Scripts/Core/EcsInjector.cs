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
            if (!type.IsAssignableFrom(injectionObject.GetType()))
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

        public void ExecuteInjection(IEcsSystems ecsSystems)
        {
            Inject(ecsSystems, ecsSystems.GetWorld(), typeof(EcsWorld));
            
            foreach (var (injectionType, injectionObject) in _injectedObjects)
            {
                Inject(ecsSystems, injectionObject, injectionType);
            }

            InjectPools(ecsSystems);
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
                var systemType = system.GetType();
                var systemFields = systemType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var requiredField = systemFields.FirstOrDefault(x => x.FieldType == injectionType);
                if (requiredField != null)
                {
                    requiredField.SetValue(system, injectedObject);
                }
            }
            
            return ecsSystems;
        }

        public static IEcsSystem Inject(IEcsSystem system, object injectedObject)
        {
            return Inject(system, injectedObject, injectedObject.GetType());
        }

        public static IEcsSystem Inject(IEcsSystem system, object injectedObject, Type injectionType)
        {
            var systemType = system.GetType();
            var systemFields = systemType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var requiredField = systemFields.FirstOrDefault(x => x.FieldType == injectionType);
            if (requiredField != null)
            {
                requiredField.SetValue(system, injectedObject);
            }
            
            return system;
        }

        private IEcsSystems InjectPools(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

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
    }
}