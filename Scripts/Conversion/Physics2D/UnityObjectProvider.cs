#if LEOECSLITE_ZOO_PHYSICS2D
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public partial class UnityObjectProvider
    {
        partial void SetupPhysics2D()
        {
            if (TryGetComponent<Rigidbody2D>(out var rb2d)) 
                Add<UnityObjectRef<Rigidbody2D>>().Value = rb2d;
        }
    }
}
#endif
