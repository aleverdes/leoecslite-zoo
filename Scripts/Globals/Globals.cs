using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public static class Globals
    {
        private static readonly Dictionary<Type, object> Objects = new Dictionary<Type, object>();

        public static void Add(object sharedData)
        {
            Objects.Add(sharedData.GetType(), sharedData);
        }

        public static void Remove(object sharedData)
        {
            Objects.Remove(sharedData.GetType());
        }

        public static void Remove<T>()
        {
            Objects.Remove(typeof(T));
        }

        public static bool Has<T>()
        {
            return Objects.ContainsKey(typeof(T));
        }

        public static T Get<T>()
        {
            return (T) Objects[typeof(T)];
        }

        public static bool TryGet<T>(out T value)
        {
            var result = Objects.TryGetValue(typeof(T), out var tempValue);
            value = (T)tempValue;
            return result;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetSharedData()
        {
            Objects.Clear();
        }
    }
}