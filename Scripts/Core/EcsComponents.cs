using System;

namespace AleVerDes.LeoEcsLiteZoo
{
    [Serializable]
    public struct UnityObjectRef<T> where T : UnityEngine.Object
    {
        public T Value;
    }
}