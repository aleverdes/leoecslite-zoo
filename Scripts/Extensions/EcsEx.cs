using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using Random = UnityEngine.Random;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class EcsEx
    {
        private static List<Type> _tempListOfEntityTypes = new List<Type>();
        
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
        
        public static ref T NewEntityWith<T>(this EcsWorld ecsWorld, out EcsPackedEntityWithWorld entity) where T : struct
        {
            var e = ecsWorld.NewEntity();
            entity = ecsWorld.PackEntityWithWorld(e);
            return ref ecsWorld.GetPool<T>().Add(e);
        }
        
        public static ref T NewEntityWith<T>(this EcsWorld ecsWorld, T value) where T : struct
        {
            var entity = ecsWorld.NewEntity();
            ref var component = ref ecsWorld.GetPool<T>().Add(entity);
            component = value;
            return ref component;
        }
        
        public static ref T NewEntityWith<T>(this EcsWorld ecsWorld, T value, out int entity) where T : struct
        {
            entity = ecsWorld.NewEntity();
            ref var component = ref ecsWorld.GetPool<T>().Add(entity);
            component = value;
            return ref component;
        }
        
        public static ref T NewEntityWith<T>(this EcsWorld ecsWorld, T value, out EcsPackedEntityWithWorld entity) where T : struct
        {
            var e = ecsWorld.NewEntity();
            entity = ecsWorld.PackEntityWithWorld(e);
            ref var component = ref ecsWorld.GetPool<T>().Add(e);
            component = value;
            return ref component;
        }

        public static int GetFirstEntity<T>(this EcsWorld world) where T : struct
        {
            return world.GetFirstEntity<T>(out _);
        }

        public static int GetFirstEntity<T>(this EcsWorld world, out T component) where T : struct
        {
            if (world.TryGetFirstEntity(out int entity, out component))
                return entity;

            throw new Exception($"Entity with component \"{typeof(T)}\" not found");
        }

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out int entity) where T : struct
        {
            return ecsWorld.TryGetFirstEntity(out entity, out T _);
        }

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out EcsPackedEntityWithWorld entity) where T : struct
        {
            return ecsWorld.TryGetFirstEntity(out entity, out T _);
        }

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out T component) where T : struct
        {
            return ecsWorld.TryGetFirstEntity(out int _, out component);
        }

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out int entity, out T component) where T : struct
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

        public static bool TryGetFirstEntity<T>(this EcsWorld ecsWorld, out EcsPackedEntityWithWorld entity, out T component) where T : struct
        {
            var filter = ecsWorld.Filter<T>().End();
            var pool = ecsWorld.GetPool<T>();
            foreach (var e in filter)
            {
                component = pool.Get(e);
                entity = ecsWorld.PackEntityWithWorld(e);
                return true;
            }

            component = default;
            entity = default;
            return false;
        }

        public static int GetFirstEntity<T>(this EcsFilter filter) where T : struct
        {
            return filter.GetFirstEntity<T>(out _);
        }

        public static int GetFirstEntity<T>(this EcsFilter filter, out T component) where T : struct
        {
            if (filter.TryGetFirstEntity(out var entity, out component))
                return entity;

            throw new Exception($"Entity with component \"{typeof(T)}\" not found");
        }

        public static bool TryGetFirstEntity<T>(this EcsFilter filter, out int entity) where T : struct
        {
            return filter.TryGetFirstEntity(out entity, out T _);
        }

        public static bool TryGetFirstEntity<T>(this EcsFilter filter, out T component) where T : struct
        {
            return filter.TryGetFirstEntity(out _, out component);
        }

        public static bool TryGetFirstEntity<T>(this EcsFilter filter, out int entity, out T component) where T : struct
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
        
        public static int GetRandomEntity<T>(this EcsWorld world) where T : struct
        {
            return world.GetRandomEntity<T>(out _);
        }

        public static int GetRandomEntity<T>(this EcsWorld world, out T component) where T : struct
        {
            if (world.TryGetRandomEntity(out int entity, out component))
                return entity;

            throw new Exception($"Entity with component \"{typeof(T)}\" not found");
        }

        public static bool TryGetRandomEntity<T>(this EcsWorld ecsWorld, out int entity) where T : struct
        {
            return ecsWorld.TryGetRandomEntity(out entity, out T _);
        }
        
        public static bool TryGetRandomEntity<T>(this EcsWorld ecsWorld, out EcsPackedEntityWithWorld entity) where T : struct
        {
            return ecsWorld.TryGetRandomEntity(out entity, out T _);
        }

        public static bool TryGetRandomEntity<T>(this EcsWorld ecsWorld, out T component) where T : struct
        {
            return ecsWorld.TryGetRandomEntity(out int _, out component);
        }

        public static bool TryGetRandomEntity<T>(this EcsWorld ecsWorld, out int entity, out T component) where T : struct
        {
            var filter = ecsWorld.Filter<T>().End();
            var pool = ecsWorld.GetPool<T>();

            if (filter.GetEntitiesCount() == 0)
            {
                throw new IndexOutOfRangeException("World's filter is empty");
            }

            var randomIndex = Random.Range(0, filter.GetEntitiesCount());

            foreach (var e in filter)
            {
                if (randomIndex == 0)
                {
                    component = pool.Get(e);
                    entity = e;
                    return true;
                }
                randomIndex--;
            }

            component = default;
            entity = -1;
            return false;
        }

        public static bool TryGetRandomEntity<T>(this EcsWorld ecsWorld, out EcsPackedEntityWithWorld entity, out T component) where T : struct
        {
            var filter = ecsWorld.Filter<T>().End();
            var pool = ecsWorld.GetPool<T>();

            if (filter.GetEntitiesCount() == 0)
            {
                throw new IndexOutOfRangeException("World's filter is empty");
            }

            var randomIndex = Random.Range(0, filter.GetEntitiesCount());

            foreach (var e in filter)
            {
                if (randomIndex == 0)
                {
                    component = pool.Get(e);
                    entity = ecsWorld.PackEntityWithWorld(e);
                    return true;
                }
                randomIndex--;
            }

            component = default;
            entity = default;
            return false;
        }

        public static int GetRandomEntity<T>(this EcsFilter filter) where T : struct
        {
            return filter.GetRandomEntity<T>(out _);
        }

        public static int GetRandomEntity<T>(this EcsFilter filter, out T component) where T : struct
        {
            if (filter.TryGetRandomEntity( out var entity, out component))
            {
                return entity;
            }

            throw new Exception($"Entity with component \"{typeof(T)}\" not found");
        }

        public static bool TryGetRandomEntity<T>(this EcsFilter filter, out int entity) where T : struct
        {
            return filter.TryGetRandomEntity(out entity, out T _);
        }

        public static bool TryGetRandomEntity<T>(this EcsFilter filter, out T component) where T : struct
        {
            return filter.TryGetRandomEntity(out _, out component);
        }

        public static bool TryGetRandomEntity<T>(this EcsFilter filter, out int entity, out T component) where T : struct
        {
            var pool = filter.GetWorld().GetPool<T>();

            if (filter.GetEntitiesCount() == 0)
            {
                throw new IndexOutOfRangeException("World's filter is empty");
            }

            var randomIndex = Random.Range(0, filter.GetEntitiesCount());

            foreach (var e in filter)
            {
                if (randomIndex == 0)
                {
                    component = pool.Get(e);
                    entity = e;
                    return true;
                }
                randomIndex--;
            }

            component = default;
            entity = -1;
            return false;
        }

        public static bool TryGetUnityRefValue<T>(this EcsWorld ecsWorld, out T component) where T : UnityEngine.Object
        {
            return TryGetUnityRefValue(ecsWorld, out component, out _);
        }

        public static bool TryGetUnityRefValue<T>(this EcsWorld ecsWorld, out T component, out int entity) where T : UnityEngine.Object 
        {
            var filter = ecsWorld.Filter<UnityObjectRef<T>>().End();
            var pool = ecsWorld.GetPool<UnityObjectRef<T>>();
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

        public static bool TryGetUnityRefValue<T>(this EcsFilter filter, out T component) where T : UnityEngine.Object
        {
            return TryGetUnityRefValue(filter, out component, out _);
        }

        public static bool TryGetUnityRefValue<T>(this EcsFilter filter, out T component, out int entity) where T : UnityEngine.Object
        {
            var ecsWorld = filter.GetWorld();
            var pool = ecsWorld.GetPool<UnityObjectRef<T>>();
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

        public static IEnumerable<Type> GetAllComponentsOnEntity(this EcsWorld world, int entity)
        {
            _tempListOfEntityTypes.Clear();
            var pools = default(IEcsPool[]);
            var poolsCount = world.GetAllPools(ref pools);
            for (var i = 0; i < poolsCount; i++)
                if (pools[i].Has(entity)) 
                    _tempListOfEntityTypes.Add(pools[i].GetType().GenericTypeArguments[0]);

            return _tempListOfEntityTypes;
        }
        
        public static ref T Get<T>(this EcsPackedEntityWithWorld entity) where T : struct
        {
            return ref entity.World.GetPool<T>().Get(entity.Id);
        }
    }
}