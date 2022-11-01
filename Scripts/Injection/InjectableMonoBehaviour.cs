using UnityEngine;

namespace AffenCode
{
    public abstract class InjectableMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            LeoEcsLiteInjector.AddInjection(this);
        }

        protected virtual  void OnDestroy()
        {
            LeoEcsLiteInjector.RemoveInjection(this);
        }
    }
}