using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class UnityEx
    {
        public static bool TryGetEntity(this GameObject gameObject, EcsWorld world, out EcsPackedEntityWithWorld entity)
        {
            var convertToEntity = gameObject.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            entity = convertToEntity.Convert(world);
            return true;
        }
        
        public static bool TryGetEntity(this Transform transform, EcsWorld world, out EcsPackedEntityWithWorld entity)
        {
            var convertToEntity = transform.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }
            
            entity = convertToEntity.Convert(world);
            return true;
        }
        
        public static bool TryGetEntity(this Component component, EcsWorld world, out EcsPackedEntityWithWorld entity)
        {
            var convertToEntity = component.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            entity = convertToEntity.Convert(world);
            return true;
        }
    }
}