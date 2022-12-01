using UnityEngine;

namespace AffenCode
{
    public abstract class GlobalMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            LeoEcsLiteInjector.AddInjection(this);
            Globals.Add(this);
        }

        protected virtual  void OnDestroy()
        {
            LeoEcsLiteInjector.RemoveInjection(this);
            Globals.Remove(this);
        }
    }
}