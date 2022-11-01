using UnityEngine;

namespace AffenCode
{
    public class Inject : MonoBehaviour
    {
        [SerializeField] private Component Component;
            
        protected virtual void Awake()
        {
            LeoEcsLiteInjector.AddInjection(Component);
        }

        protected virtual  void OnDestroy()
        {
            LeoEcsLiteInjector.RemoveInjection(Component);
        }
    }
}