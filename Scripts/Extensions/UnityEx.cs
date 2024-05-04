using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class UnityEx
    {
        public static bool TryGetEntity(this GameObject gameObject, out EcsPackedEntityWithWorld entity)
        {
            var convertToEntity = gameObject.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            entity = convertToEntity.GetEntity();
            return true;
        }
        
        public static bool TryGetEntity(this Transform transform, out EcsPackedEntityWithWorld entity)
        {
            var convertToEntity = transform.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }
            
            entity = convertToEntity.GetEntity();
            return true;
        }
        
        public static bool TryGetEntity(this Component component, out EcsPackedEntityWithWorld entity)
        {
            var convertToEntity = component.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            entity = convertToEntity.GetEntity();
            return true;
        }
    }
}