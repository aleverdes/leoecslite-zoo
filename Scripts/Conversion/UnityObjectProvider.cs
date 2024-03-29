using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [RequireComponent(typeof(ConvertToEntity))]
    public class UnityObjectProvider : MonoBehaviour, IConvertableToEntity
    {
        public void ConvertToEntity(EcsWorld world, int entity)
        {
            world.GetPool<TransformRef>().Add(entity).Value = transform;
            world.GetPool<Ref<Transform>>().Add(entity).Value = transform;

            if (transform is RectTransform rectTransform)
            {
                world.GetPool<RectTransformRef>().Add(entity).Value = rectTransform;
                world.GetPool<Ref<RectTransform>>().Add(entity).Value = rectTransform;
            }

            world.GetPool<GameObjectRef>().Add(entity).Value = gameObject;
            world.GetPool<Ref<GameObject>>().Add(entity).Value = gameObject;

            if (TryGetComponent<Rigidbody>(out var rb))
            {
                world.GetPool<RigidbodyRef>().Add(entity).Value = rb;
                world.GetPool<Ref<Rigidbody>>().Add(entity).Value = rb;
            }

            if (TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                world.GetPool<Rigidbody2DRef>().Add(entity).Value = rb2d;
                world.GetPool<Ref<Rigidbody2D>>().Add(entity).Value = rb2d;
            }
        }
    }
}