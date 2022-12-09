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

            var ecsTransforms = world.GetPool<EcsTransform>();
            var transformRefs = world.GetPool<TransformRef>();
            var rectTransformRefs = world.GetPool<RectTransformRef>();
            var rigidbodyRefs = world.GetPool<RigidbodyRef>();
            var rigidbody2DRefs = world.GetPool<Rigidbody2DRef>();

            var globalTransformFilter = world.Filter<EcsTransform>().Inc<TransformRef>().Exc<IgnoreTransformSync>().Exc<LocalTransformSync>().End();
            foreach (var entity in globalTransformFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ecsTransform.Position = unityTransform.Value.position;
                ecsTransform.Rotation = unityTransform.Value.rotation;
                ecsTransform.Scale = unityTransform.Value.localScale;
            }

            var localTransformFilter = world.Filter<EcsTransform>().Inc<TransformRef>().Exc<IgnoreTransformSync>().Inc<LocalTransformSync>().End();
            foreach (var entity in localTransformFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ecsTransform.Position = unityTransform.Value.localPosition;
                ecsTransform.Rotation = unityTransform.Value.localRotation;
                ecsTransform.Scale = unityTransform.Value.localScale;
            }

            var rectTransformFilter = world.Filter<EcsTransform>().Inc<RectTransformRef>().Exc<IgnoreTransformSync>().End();
            foreach (var entity in rectTransformFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var rectTransformRef = ref rectTransformRefs.Get(entity);
                ecsTransform.Position = rectTransformRef.Value.anchoredPosition;
                ecsTransform.Rotation = rectTransformRef.Value.rotation;
                ecsTransform.Scale = rectTransformRef.Value.localScale;
            }

            var globalRigidbodyFilter = world.Filter<EcsTransform>().Inc<RigidbodyRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Exc<LocalTransformSync>().End();
            foreach (var entity in globalRigidbodyFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbodyRef = ref rigidbodyRefs.Get(entity);
                ecsTransform.Position = rigidbodyRef.Value.position;
                ecsTransform.Rotation = rigidbodyRef.Value.rotation;
                ecsTransform.Scale = unityTransform.Value.localScale;
            }

            var localRigidbodyFilter = world.Filter<EcsTransform>().Inc<RigidbodyRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Inc<LocalTransformSync>().End();
            foreach (var entity in localRigidbodyFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ecsTransform.Position = unityTransform.Value.localPosition;
                ecsTransform.Rotation = unityTransform.Value.localRotation;
                ecsTransform.Scale = unityTransform.Value.localScale;
            }

            var globalRigidbody2DFilter = world.Filter<EcsTransform>().Inc<Rigidbody2DRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Exc<LocalTransformSync>().End();
            foreach (var entity in globalRigidbody2DFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbody2DRef = ref rigidbody2DRefs.Get(entity);
                ecsTransform.Position = unityTransform.Value.position;
                ecsTransform.Rotation = Quaternion.Euler(0, 0, rigidbody2DRef.Value.rotation);
                ecsTransform.Scale = unityTransform.Value.localScale;
            }

            var localRigidbody2DFilter = world.Filter<EcsTransform>().Inc<Rigidbody2DRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Inc<LocalTransformSync>().End();
            foreach (var entity in localRigidbody2DFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbody2DRef = ref rigidbody2DRefs.Get(entity);
                ecsTransform.Position = unityTransform.Value.localPosition;
                ecsTransform.Rotation = Quaternion.Euler(0, 0, rigidbody2DRef.Value.rotation);
                ecsTransform.Scale = unityTransform.Value.localScale;
            }
        }
    }
}