using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public class SyncFromUnityTransformSystem : IEcsPreInitSystem, IEcsRunSystem
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
                ecsTransform.Position = unityTransform.Value.position;
                ecsTransform.Rotation = unityTransform.Value.rotation;
                ecsTransform.Scale = unityTransform.Value.localScale;
            }
        
            foreach (var entity in rectTransformFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var rectTransformRef = ref rectTransformRefs.Get(entity);
                ecsTransform.Position = rectTransformRef.Value.anchoredPosition;
                ecsTransform.Rotation = rectTransformRef.Value.rotation;
                ecsTransform.Scale = rectTransformRef.Value.localScale;
            }
        
            foreach (var entity in rigidbodyFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbodyRef = ref rigidbodyRefs.Get(entity);
                ecsTransform.Position = rigidbodyRef.Value.position;
                ecsTransform.Rotation = rigidbodyRef.Value.rotation;
                ecsTransform.Scale = unityTransform.Value.localScale;
            }
        
            foreach (var entity in rigidbody2DFilter) {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbody2DRef = ref rigidbody2DRefs.Get(entity);
                ecsTransform.Position = rigidbody2DRef.Value.position;
                ecsTransform.Rotation = Quaternion.Euler(0, 0, rigidbody2DRef.Value.rotation);
                ecsTransform.Scale = unityTransform.Value.localScale;
            }
        }
    }
}