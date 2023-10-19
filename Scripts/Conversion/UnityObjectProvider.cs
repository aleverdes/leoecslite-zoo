using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [RequireComponent(typeof(ConvertToEntity))]
    public class UnityObjectProvider : MonoBehaviour, IConvertToEntity
    {
        public void ConvertToEntity(EcsWorld world, int entity)
        {
            world.GetPool<TransformRef>().Add(entity) = new TransformRef()
            {
                Value = transform
            };

            if (transform is RectTransform rectTransform)
            {
                world.GetPool<RectTransformRef>().Add(entity) = new RectTransformRef()
                {
                    Value = rectTransform
                };
            }

            world.GetPool<GameObjectRef>().Add(entity) = new GameObjectRef()
            {
                Value = gameObject
            };
            
            if (TryGetComponent<Rigidbody>(out var rb))
            {
                world.GetPool<RigidbodyRef>().Add(entity) = new RigidbodyRef()
                {
                    Value = rb
                };
            }
            
            if (TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                world.GetPool<Rigidbody2DRef>().Add(entity) = new Rigidbody2DRef()
                {
                    Value = rb2d
                };
            }
            
        }
    }
}