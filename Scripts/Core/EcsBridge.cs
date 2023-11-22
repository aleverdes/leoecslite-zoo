using System;
using System.Collections.Generic;
using System.Linq;
using Leopotam.EcsLite;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace AleVerDes.LeoEcsLiteZoo
{
    public class EcsBridge : MonoBehaviour
    {
        [SerializeField] protected EcsRunner EcsRunner;

        private readonly Dictionary<Type, object> _services = new();

        private void Reset()
        {
#if UNITY_EDITOR
            if (PrefabStageUtility.GetCurrentPrefabStage() == null)
                EcsRunner = FindObjectOfType<EcsRunner>();
            else
                EcsRunner = (EcsRunner)PrefabStageUtility
                    .GetCurrentPrefabStage()
                    .FindComponentsOfType<Transform>()
                    .Where(x => x.GetComponent(typeof(EcsRunner)))
                    .Select(x => x.GetComponent(typeof(EcsRunner)))
                    .FirstOrDefault();
#endif
        }

        public int NewEntity()
        {
            return EcsRunner.GetWorld().NewEntity();
        }

        public ref T NewEntityWith<T>() where T : struct
        {
            return ref EcsRunner.GetWorld().NewEntityWith<T>();
        }

        public void DelEntity(int entity)
        {
            EcsRunner.GetWorld().DelEntity(entity);
        }

        public EcsPool<T> GetPool<T>() where T : struct
        {
            return EcsRunner.GetWorld().GetPool<T>();
        }

        public T GetService<T>()
        {
            if (_services.TryGetValue(typeof(T), out var service) && service != null)
                return (T) service;
            
            var injectors = EcsRunner.GetManager().GetInjectors();
            foreach (var injector in injectors)
            {
                var services = injector.GetInjectionObjects();
                foreach (var s in services)
                {
                    if (s.Key == typeof(T))
                    {
                        _services[s.Key] = s.Value;
                        return (T) s.Value;
                    }
                }
            }

            return default;
        }

        public EcsWorld GetWorld()
        {
            return EcsRunner.GetWorld();
        }
    }
}