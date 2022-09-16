using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public class EcsWorldProvider : MonoBehaviour
    {
        public static EcsWorldProvider DefaultWorldProvider { get; private set; }
        
        public EcsWorld World { get; private set; }

        private void Awake()
        {
            World = new EcsWorld();
            if (!DefaultWorldProvider)
            {
                DefaultWorldProvider = this;
            }
        }

        private void OnDestroy()
        {
            World?.Destroy();
            World = null;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetDefaultWorld()
        {
            if (DefaultWorldProvider)
            {
                DefaultWorldProvider.World?.Destroy();
                DefaultWorldProvider.World = null;
            }
            DefaultWorldProvider = null;
        }
    }
}