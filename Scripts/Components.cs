using System;
using UnityEngine;

namespace AffenCode
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
}