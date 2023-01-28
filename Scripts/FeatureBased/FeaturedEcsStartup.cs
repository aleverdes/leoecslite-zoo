using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public abstract class FeaturedEcsStartup : MonoBehaviour
    {
        public EcsWorldProvider WorldProvider;

        public bool InitializeOnStart = true;

        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;
        private EcsSystems _fixedUpdateSystems;

        private bool _initialized;

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
            if (_initialized)
            {
                return;
            }
            
            _updateSystems = new EcsSystems(WorldProvider.World);
            _lateUpdateSystems = new EcsSystems(WorldProvider.World);
            _fixedUpdateSystems = new EcsSystems(WorldProvider.World);
            
            _updateSystems.Add(new SyncFromUnityTransformSystem());
            _lateUpdateSystems.Add(new SyncFromUnityTransformSystem());
            _fixedUpdateSystems.Add(new SyncFromUnityTransformSystem());
            
            AddFeatures(new FeatureEcsSystems(_updateSystems, _lateUpdateSystems, _fixedUpdateSystems));
            
            _updateSystems.Add(new SyncToUnityTransformSystem());
            _lateUpdateSystems.Add(new SyncToUnityTransformSystem());
            _fixedUpdateSystems.Add(new SyncToUnityTransformSystem());
            
            _updateSystems.Inject();
            _lateUpdateSystems.Inject();
            _fixedUpdateSystems.Inject();
            
            _updateSystems.Init();
            _lateUpdateSystems.Init();
            _fixedUpdateSystems.Init();

            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized)
            {
                return;
            }
            
            _updateSystems?.Run();
        }

        private void LateUpdate()
        {
            if (!_initialized)
            {
                return;
            }

            _lateUpdateSystems?.Run();
        }

        private void FixedUpdate()
        {
            if (!_initialized)
            {
                return;
            }

            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            if (!_initialized)
            {
                return;
            }
            
            _updateSystems?.Destroy();
            _updateSystems = null;
            
            _lateUpdateSystems?.Destroy();
            _lateUpdateSystems = null;
            
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
        }

        protected abstract void AddFeatures(FeatureEcsSystems systems);
    }
}