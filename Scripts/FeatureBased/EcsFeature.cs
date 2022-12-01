using Leopotam.EcsLite;

namespace AffenCode
{
    public interface IEcsFeature
    {
        public void Update(IEcsSystems ecsSystems);
        public void LateUpdate(IEcsSystems ecsSystems);
        public void FixedUpdate(IEcsSystems ecsSystems);
    }
}