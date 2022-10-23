using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public static class ConversionUtils
    {
        public static void SetupGameObjectRef(EcsWorld ecsWorld, int entity, GameObject gameObject)
        {
            var gameObjects = ecsWorld.GetPool<GameObjectRef>();
            gameObjects.Add(entity) = new GameObjectRef
            {
                Value = gameObject
            };
        }

        public static void SetupTransformRef(EcsWorld ecsWorld, int entity, Transform transform)
        {
            if (transform is RectTransform rectTransform)
            {
                var rectTransforms = ecsWorld.GetPool<RectTransformRef>();
                rectTransforms.Add(entity) = new RectTransformRef
                {
                    Value = rectTransform
                };
                
                var ecsTransforms = ecsWorld.GetPool<EcsTransform>();
                ecsTransforms.Add(entity) = new EcsTransform
                {
                    Position = rectTransform.anchoredPosition,
                    Rotation = rectTransform.rotation,
                    Scale = rectTransform.localScale,
                };
            }
            else
            {
                var transforms = ecsWorld.GetPool<TransformRef>();
                transforms.Add(entity) = new TransformRef
                {
                    Value = transform
                };

                var ecsTransforms = ecsWorld.GetPool<EcsTransform>();
                ecsTransforms.Add(entity) = new EcsTransform
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    Scale = transform.localScale,
                };
            }
        }
        public static void SetupRigidbody(EcsWorld ecsWorld, int entity, Rigidbody rigidbody)
        {
            var rigidbodies = ecsWorld.GetPool<RigidbodyRef>();
            rigidbodies.Add(entity) = new RigidbodyRef
            {
                Value = rigidbody
            };
        }

        public static void SetupRigidbody2D(EcsWorld ecsWorld, int entity, Rigidbody2D rigidbody2d)
        {
            var rigidbodies2D = ecsWorld.GetPool<Rigidbody2DRef>();
            rigidbodies2D.Add(entity) = new Rigidbody2DRef
            {
                Value = rigidbody2d
            };
        }
    }
}