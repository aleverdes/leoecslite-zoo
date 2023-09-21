using Leopotam.EcsLite;

namespace AleVerDes
{
    public static class DelHereEx
    {
        public static IEcsSystems DelHere<T>(this IEcsSystems ecsSystems) where T : struct
        {
            ecsSystems.Add(new DelHereSystem<T>());
            return ecsSystems;
        }
        
        public static EcsFeatureSystems DelHere<T>(this EcsFeatureSystems ecsSystems) where T : struct
        {
            ecsSystems.Add(new DelHereSystem<T>());
            return ecsSystems;
        }
    }
}