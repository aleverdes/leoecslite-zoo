using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public class SyncToUnityTransformSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        public void PreInit(IEcsSystems systems)
        {
            SyncTransforms(systems);
        }

        public void Run(IEcsSystems systems)
        {
            SyncTransforms(systems);
        }

        private static void SyncTransforms(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var transformFilter = world.Filter<EcsTransform>().Inc<TransformRef>().Exc<IgnoreTransformSync>().End();
            var rectTransformFilter = world.Filter<EcsTransform>().Inc<RectTransformRef>().Exc<IgnoreTransformSync>().End();
            var rigidbodyFilter = world.Filter<EcsTransform>().Inc<RigidbodyRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().End();
            var rigidbody2DFilter = world.Filter<EcsTransform>().Inc<Rigidbody2DRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().End();

            var ecsTransforms = world.GetPool<EcsTransform>();
            var transformRefs = world.GetPool<TransformRef>();
            var rectTransformRefs = world.GetPool<RectTransformRef>();
            var rigidbodyRefs = world.GetPool<RigidbodyRef>();
            var rigidbody2DRefs = world.GetPool<Rigidbody2DRef>();
        
            foreach (var entity in transformFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                unityTransform.Value.position = ecsTransform.Position;
                unityTransform.Value.rotation = ecsTransform.Rotation;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }
        
            foreach (var entity in rectTransformFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var rectTransformRef = ref rectTransformRefs.Get(entity);
                rectTransformRef.Value.anchoredPosition = ecsTransform.Position;
                rectTransformRef.Value.rotation = ecsTransform.Rotation;
                rectTransformRef.Value.localScale = ecsTransform.Scale;
            }
        
            foreach (var entity in rigidbodyFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbodyRef = ref rigidbodyRefs.Get(entity);
                rigidbodyRef.Value.position = ecsTransform.Position; 
                rigidbodyRef.Value.rotation = ecsTransform.Rotation;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }
        
            foreach (var entity in rigidbody2DFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbody2DRef = ref rigidbody2DRefs.Get(entity);
                rigidbody2DRef.Value.position = ecsTransform.Position;
                rigidbody2DRef.Value.rotation = ecsTransform.Rotation.eulerAngles.z;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }
        }
    }
}