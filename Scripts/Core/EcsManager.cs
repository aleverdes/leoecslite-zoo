using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AffenCode
{
    public sealed class EcsManager
    {
        private readonly HashSet<EcsFeatureGroup> _systemsContexts = new HashSet<EcsFeatureGroup>();
        private readonly HashSet<EcsInjector> _injectors = new HashSet<EcsInjector>();
        
        private EcsWorld _world;
        
        public void AddInjector(EcsInjector injector)
        {
            _injectors.Add(injector);

            foreach (var systemsContext in _systemsContexts)
            {
                injector.ExecuteInjection(systemsContext.SystemsGroup.UpdateSystems);
                injector.ExecuteInjection(systemsContext.SystemsGroup.LateUpdateSystems);
                injector.ExecuteInjection(systemsContext.SystemsGroup.FixedUpdateSystems);
            }
        }

        public void SetWorld(EcsWorld ecsWorld)
        {
            _world = ecsWorld;
        }

        public void Update()
        {
            foreach (var systemsContext in _systemsContexts)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.SystemsGroup.UpdateSystems.Run();
                }
            }
        }

        public void LateUpdate()
        {
            foreach (var systemsContext in _systemsContexts)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.SystemsGroup.LateUpdateSystems.Run();
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (var systemsContext in _systemsContexts)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.SystemsGroup.FixedUpdateSystems.Run();
                }
            }
        }

        public void Destroy()
        {
            foreach (var systemsContext in _systemsContexts)
            {
                systemsContext.SystemsGroup.Destroy();
            }
        }

        public void AddFeatureGroup(EcsFeatureGroup featureGroup)
        {
            featureGroup.Initialize(_world);
            
            foreach (var injector in _injectors)
            {
                injector.ExecuteInjection(featureGroup.SystemsGroup.UpdateSystems);
                injector.ExecuteInjection(featureGroup.SystemsGroup.LateUpdateSystems);
                injector.ExecuteInjection(featureGroup.SystemsGroup.FixedUpdateSystems);
            }
            
            _systemsContexts.Add(featureGroup);
            
            featureGroup.SystemsGroup.Init();
        }

        public void RemoveFeatureGroup(EcsFeatureGroup featureGroup)
        {
            featureGroup.SystemsGroup.Destroy();
            
            _systemsContexts.Remove(featureGroup);
        }
    }
}