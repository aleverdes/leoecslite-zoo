using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public class EcsWorldProvider : MonoBehaviour
    {
        public static EcsWorld DefaultWorld => DefaultWorldProvider ? DefaultWorldProvider.World : null;
        public static EcsWorldProvider DefaultWorldProvider { get; private set; }
        
        public EcsWorld World { get; private set; }

        private void Awake()
        {
            World = new EcsWorld();
            
            if (!DefaultWorldProvider)
            {
                DefaultWorldProvider = this;
            }

            ConvertToEntity.DefaultConversionWorld ??= World;
        }

        private void OnDestroy()
        {
            if (DefaultWorldProvider == this)
            {
                DefaultWorldProvider = null;
            }

            if (ConvertToEntity.DefaultConversionWorld == World)
            {
                ConvertToEntity.DefaultConversionWorld = null;
            }
            
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
            ConvertToEntity.DefaultConversionWorld = null;
        }
    }
}