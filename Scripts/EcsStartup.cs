using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public abstract class EcsStartup : MonoBehaviour
    {
        public EcsWorldProvider WorldProvider;

        public bool InitializeOnStart = true;

        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Reset()
        {
            WorldProvider = FindObjectOfType<EcsWorldProvider>();
        }

        private void Start()
        {
            if (InitializeOnStart)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            _updateSystems = new EcsSystems(WorldProvider.World);
            AddUpdateSystems(_updateSystems);
            _updateSystems.Inject();
            _updateSystems.Init();
            
            _lateUpdateSystems = new EcsSystems(WorldProvider.World);
            AddLateUpdateSystems(_lateUpdateSystems);
            _lateUpdateSystems.Inject();
            _lateUpdateSystems.Init();
            
            _fixedUpdateSystems = new EcsSystems(WorldProvider.World);
            AddFixedUpdateSystems(_fixedUpdateSystems);
            _fixedUpdateSystems.Inject();
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _updateSystems = null;
            
            _lateUpdateSystems?.Destroy();
            _lateUpdateSystems = null;
            
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
        }

        protected abstract void AddUpdateSystems(EcsSystems ecsSystems);
        protected abstract void AddLateUpdateSystems(EcsSystems ecsSystems);
        protected abstract void AddFixedUpdateSystems(EcsSystems ecsSystems);
    }
}