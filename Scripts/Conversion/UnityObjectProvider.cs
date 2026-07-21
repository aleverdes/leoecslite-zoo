using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [RequireComponent(typeof(ConvertToEntity))]
    public partial class UnityObjectProvider : EcsEntityProvider
    {
        protected override void Setup()
        {
            Add<UnityObjectRef<GameObject>>().Value = gameObject;
            
            Add<UnityObjectRef<Transform>>().Value = transform;
            if (transform is RectTransform rectTransform) 
                Add<UnityObjectRef<RectTransform>>().Value = rectTransform;
            
            SetupPhysics();
            SetupPhysics2D();
        }

        partial void SetupPhysics();
        partial void SetupPhysics2D();
    }
}