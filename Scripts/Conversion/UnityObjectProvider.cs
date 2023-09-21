using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [RequireComponent(typeof(ConvertToEntity))]
    public class UnityObjectProvider : MonoBehaviour, IConvertToEntity
    {
        public void ConvertToEntity(EcsWorld ecsWorld, int entity)
        {
            ecsWorld.GetPool<TransformRef>().Add(entity) = new TransformRef()
            {
                Value = transform
            };

            if (transform is RectTransform rectTransform)
            {
                ecsWorld.GetPool<RectTransformRef>().Add(entity) = new RectTransformRef()
                {
                    Value = rectTransform
                };
            }

            ecsWorld.GetPool<GameObjectRef>().Add(entity) = new GameObjectRef()
            {
                Value = gameObject
            };
            
            if (TryGetComponent<Rigidbody>(out var rb))
            {
                ecsWorld.GetPool<RigidbodyRef>().Add(entity) = new RigidbodyRef()
                {
                    Value = rb
                };
            }
            
            if (TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                ecsWorld.GetPool<Rigidbody2DRef>().Add(entity) = new Rigidbody2DRef()
                {
                    Value = rb2d
                };
            }
            
        }
    }
}