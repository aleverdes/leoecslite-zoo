using Leopotam.EcsLite;

namespace AffenCode
{
    public static class EcsWorldEx
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
    }
}