using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [Serializable]
    public struct TransformRef
    {
        public Transform Value;
    }

    [Serializable]
    public struct RectTransformRef
    {
        public RectTransform Value;
    }
    
    [Serializable]
    public struct RigidbodyRef
    {
        public Rigidbody Value;
    }

    [Serializable]
    public struct Rigidbody2DRef
    {
        public Rigidbody2D Value;
    }

    [Serializable]
    public struct GameObjectRef
    {
        public GameObject Value;
    }

    [Serializable]
    public struct UnityRef<T> where T : UnityEngine.Object
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