using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace AffenCode
{
    public abstract class EcsManager
    {
        private EcsWorld _world;
        private EcsSystemsContext _systemsContext;
        private readonly List<EcsInjector> _injectors = new List<EcsInjector>();
        
        private bool _initialized;

        public void SetWorld(EcsWorld ecsWorld)
        {
            _world = ecsWorld;
        }

        public void AddInjector(EcsInjector injector)
        {
            _injectors.Add(injector);
        }

        public void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            _systemsContext = new EcsSystemsContext(this, _world);
            
            AddFeatures(_systemsContext);

            foreach (var injector in _injectors)
            {
                injector.ExecuteInjection(_systemsContext.Systems.UpdateSystems);
                injector.ExecuteInjection(_systemsContext.Systems.LateUpdateSystems);
                injector.ExecuteInjection(_systemsContext.Systems.FixedUpdateSystems);
            }

            _systemsContext.Systems.Init();

            _initialized = true;
        }

        public void Update()
        {
            if (!_initialized)
            {
                return;
            }
            
            _systemsContext.Systems.UpdateSystems.Run();
        }

        public void LateUpdate()
        {
            if (!_initialized)
            {
                return;
            }
            
            _systemsContext.Systems.LateUpdateSystems.Run();
        }

        public void FixedUpdate()
        {
            if (!_initialized)
            {
                return;
            }

            _systemsContext.Systems.FixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            if (!_initialized)
            {
                return;
            }
            
            _systemsContext.Systems.Destroy();
        }

        protected abstract void AddFeatures(EcsSystemsContext systemsContext);
    }
}