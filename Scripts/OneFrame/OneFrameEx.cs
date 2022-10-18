using Leopotam.EcsLite;

namespace AffenCode
{
    public static class OneFrameEx
    {
        public static EcsSystems OneFrame<T>(this EcsSystems ecsSystems) where T : struct
        {
            ecsSystems.Add(new OneFrameSystem<T>());
            return ecsSystems;
        }
    }
}