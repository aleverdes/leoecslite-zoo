using Leopotam.EcsLite;

namespace AleVerDes
{
    public sealed class DelHereSystem<T> : IEcsRunSystem where T : struct
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<T>().End();
            var oneFrames = world.GetPool<T>();
            foreach (var entity in filter)
            {
                oneFrames.Del(entity);
            }
        }
    }
}