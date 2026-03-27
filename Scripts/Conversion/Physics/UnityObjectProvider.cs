#if LEOECSLITE_ZOO_PHYSICS
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public partial class UnityObjectProvider
    {
        partial void SetupPhysics()
        {
            if (TryGetComponent<Rigidbody>(out var rb)) 
                Add<UnityObjectRef<Rigidbody>>().Value = rb;
        }
    }
}
#endif
