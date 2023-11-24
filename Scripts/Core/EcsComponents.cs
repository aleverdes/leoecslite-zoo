using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [Serializable]
    [Obsolete("Use ObjectRef<T> instead")]
    public struct TransformRef
    {
        public Transform Value;
    }

    [Serializable]
    [Obsolete("Use ObjectRef<T> instead")]
    public struct RectTransformRef
    {
        public RectTransform Value;
    }
    
    [Serializable]
    [Obsolete("Use ObjectRef<T> instead")]
    public struct RigidbodyRef
    {
        public Rigidbody Value;
    }

    [Serializable]
    [Obsolete("Use ObjectRef<T> instead")]
    public struct Rigidbody2DRef
    {
        public Rigidbody2D Value;
    }

    [Serializable]
    [Obsolete("Use ObjectRef<T> instead")]
    public struct GameObjectRef
    {
        public GameObject Value;
    }

    [Serializable]
    [Obsolete("Use ObjectRef<T> instead")]
    public struct UnityRef<T> where T : UnityEngine.Object
    {
        public T Value;
    }

    [Serializable]
    public struct ObjectRef<T> where T : UnityEngine.Object
    {
        public T Value;
    }

    [Serializable]
    public struct EntityRef<T> where T : struct
    {
        public int Value;
        
        public ref T Get(EcsWorld world)
        {
            return ref world.GetPool<T>().Get(Value);
        }
    }
}