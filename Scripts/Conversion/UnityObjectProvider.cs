using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    [RequireComponent(typeof(ConvertToEntity))]
    public class UnityObjectProvider : MonoBehaviour, IConvertToEntity
    {
        public void ConvertToEntity(EcsWorld ecsWorld, int entity)
        {
            var gameObjects = ecsWorld.GetPool<GameObjectRef>();
            gameObjects.Add(entity) = new GameObjectRef
            {
                Value = gameObject
            };

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
            
            if (TryGetComponent<Rigidbody>(out var rb))
            {
                var rigidbodies = ecsWorld.GetPool<RigidbodyRef>();
                rigidbodies.Add(entity) = new RigidbodyRef
                {
                    Value = rb
                };
            }
            
            if (TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                var rigidbodies2D = ecsWorld.GetPool<Rigidbody2DRef>();
                rigidbodies2D.Add(entity) = new Rigidbody2DRef
                {
                    Value = rb2d
                };
            }
        }
    }
}