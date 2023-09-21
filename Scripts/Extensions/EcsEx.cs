using System;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class EcsEx
    {
        public static ref T NewEntityWith<T>(this EcsWorld ecsWorld) where T : struct
        {
            var entity = ecsWorld.NewEntity();
            return ref ecsWorld.GetPool<T>().Add(entity);
        }
        
        public static ref T NewEntityWith<T>(this EcsWorld ecsWorld, out int entity) where T : struct
        {
            entity = ecsWorld.NewEntity();
            return ref ecsWorld.GetPool<T>().Add(entity);
        }

        public static T GetFirstEntity<T>(this EcsWorld world) where T : struct
        {
            return world.GetFirstEntity<T>(out _);
        }

        public static T GetFirstEntity<T>(this EcsWorld world, out int entity) where T : struct
        {
            if (world.TryGetFirstEntity(out T component, out entity))
            {
                return component;
            }

            throw new Exception($"Entity with component \"{typeof(T)}\" not found");
        }

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out T component) where T : struct
        {
            return ecsWorld.TryGetFirstEntity(out component, out _);
        }

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out T component, out int entity) where T : struct
        {
            var filter = ecsWorld.Filter<T>().End();
            var pool = ecsWorld.GetPool<T>();
            foreach (var e in filter)
            {
                component = pool.Get(e);
                entity = e;
                return true;
            }

            component = default;
            entity = -1;
            return false;
        }

        public static T GetFirstEntity<T>(this EcsFilter filter) where T : struct
        {
            return filter.GetFirstEntity<T>(out _);
        }

        public static T GetFirstEntity<T>(this EcsFilter filter, out int entity) where T : struct
        {
            if (filter.TryGetFirstEntity(out T component, out entity))
            {
                return component;
            }

            throw new Exception($"Entity with component \"{typeof(T)}\" not found");
        }

        public static bool TryGetFirstEntity<T>(this EcsFilter filter, out T component) where T : struct
        {
            return filter.TryGetFirstEntity(out component, out _);
        }

        public static bool TryGetFirstEntity<T>(this EcsFilter filter, out T component, out int entity) where T : struct
        {
            var pool = filter.GetWorld().GetPool<T>();
            foreach (var e in filter)
            {
                component = pool.Get(e);
                entity = e;
                return true;
            }

            component = default;
            entity = -1;
            return false;
        }

        public static bool TryGetUnityRefValue<T>(this EcsWorld ecsWorld, out T component) where T : UnityEngine.Object, IUnityRef
        {
            return TryGetUnityRefValue(ecsWorld, out component, out _);
        }

        public static bool TryGetUnityRefValue<T>(this EcsWorld ecsWorld, out T component, out int entity) where T : UnityEngine.Object, IUnityRef 
        {
            var filter = ecsWorld.Filter<UnityRef<T>>().End();
            var pool = ecsWorld.GetPool<UnityRef<T>>();
            foreach (var e in filter)
            {
                component = pool.Get(e).Value;
                entity = e;
                return true;
            }

            component = default;
            entity = -1;
            return false;
        }

        public static bool TryGetUnityRefValue<T>(this EcsFilter filter, out T component) where T : UnityEngine.Object, IUnityRef
        {
            return TryGetUnityRefValue(filter, out component, out _);
        }

        public static bool TryGetUnityRefValue<T>(this EcsFilter filter, out T component, out int entity) where T : UnityEngine.Object, IUnityRef
        {
            var ecsWorld = filter.GetWorld();
            var pool = ecsWorld.GetPool<UnityRef<T>>();
            foreach (var e in filter)
            {
                component = pool.Get(e).Value;
                entity = e;
                return true;
            }

            component = default;
            entity = -1;
            return false;
        }
    }
}