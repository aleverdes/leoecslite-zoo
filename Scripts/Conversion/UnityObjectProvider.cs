using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    [RequireComponent(typeof(ConvertToEntity))]
    public class UnityObjectProvider : MonoBehaviour, IConvertToEntity
    {
        public void ConvertToEntity(EcsWorld ecsWorld, int entity)
        {
            ConversionUtils.SetupGameObjectRef(ecsWorld, entity, gameObject);
            
            ConversionUtils.SetupTransformRef(ecsWorld, entity, transform);
            
            if (TryGetComponent<Rigidbody>(out var rb))
            {
                ConversionUtils.SetupRigidbody(ecsWorld, entity, rb);
            }
            
            if (TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                ConversionUtils.SetupRigidbody2D(ecsWorld, entity, rb2d);
            }
            
        }
    }
}