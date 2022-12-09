using UnityEngine;

namespace AffenCode
{
    public static class EcsTransformUtils
    {
        public static EcsTransform GetEcsTransform(Transform transform, bool local = false)
        {
            return new EcsTransform
            {
                Position = local ? transform.localPosition : transform.position,
                Rotation = local ? transform.localRotation : transform.rotation,
                Scale = transform.localScale,
            };
        }

        public static void SyncTransformWithEcs(this Transform transform, EcsTransform ecsTransform, bool local = false)
        {
            if (local)
            {
                transform.localPosition = ecsTransform.Position;
                transform.localRotation = ecsTransform.Rotation;
            }
            else
            {
                transform.position = ecsTransform.Position;
                transform.rotation = ecsTransform.Rotation;
            }

            transform.localScale = ecsTransform.Scale;
        }
    }
}