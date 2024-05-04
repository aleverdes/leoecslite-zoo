using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [RequireComponent(typeof(ConvertToEntity))]
    public class UnityObjectProvider : EcsEntityProvider
    {
        protected override void Setup()
        {
            Add<UnityObjectRef<GameObject>>().Value = gameObject;
            
            Add<UnityObjectRef<Transform>>().Value = transform;
            if (transform is RectTransform rectTransform) 
                Add<UnityObjectRef<RectTransform>>().Value = rectTransform;
            
            if (TryGetComponent<Rigidbody>(out var rb)) 
                Add<UnityObjectRef<Rigidbody>>().Value = rb;

            if (TryGetComponent<Rigidbody2D>(out var rb2d)) 
                Add<UnityObjectRef<Rigidbody2D>>().Value = rb2d;
        }
    }
}