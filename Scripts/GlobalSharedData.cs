using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public static class GlobalSharedData
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

        public static T Get<T>()
        {
            return (T) Objects[typeof(T)];
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetSharedData()
        {
            Objects.Clear();
        }
    }
}