using Leopotam.EcsLite;

namespace AffenCode
{
    public static class OneFrameEx
    {
        public static IEcsSystems OneFrame<T>(this IEcsSystems ecsSystems) where T : struct
        {
            ecsSystems.Add(new OneFrameSystem<T>());
            return ecsSystems;
        }
    }
}