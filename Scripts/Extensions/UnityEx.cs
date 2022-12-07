using UnityEngine;

namespace AffenCode
{
    public static class UnityEx
    {
        public static bool TryGetEntity(this GameObject gameObject, out int entity)
        {
            var convertToEntity = gameObject.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            var nullableEntity = convertToEntity.GetEntity();
            if (!nullableEntity.HasValue)
            {
                entity = default;
                return false;
            }
            
            entity = nullableEntity.Value;
            return true;
        }
        
        public static bool TryGetEntity(this Component component, out int entity)
        {
            var convertToEntity = component.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            var nullableEntity = convertToEntity.GetEntity();
            if (!nullableEntity.HasValue)
            {
                entity = default;
                return false;
            }
            
            entity = nullableEntity.Value;
            return true;
        }
    }
}