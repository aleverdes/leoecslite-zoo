using Leopotam.EcsLite;

namespace AffenCode
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
    }
}