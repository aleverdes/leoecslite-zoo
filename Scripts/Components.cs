using System;
using UnityEngine;

namespace AffenCode
{
    [Serializable]
    public struct EcsTransform
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
    }

    [Serializable]
    public struct TransformRef
    {
        public Transform Value;
    }

    [Serializable]
    public struct LocalTransformSync
    {
    }

    [Serializable]
    public struct RectTransformRef
    {
        public RectTransform Value;
    }
    
    [Serializable]
    public struct IgnoreTransformSync
    {}
    
    [Serializable]
    public struct IgnoreRigidbodySync
    {}

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