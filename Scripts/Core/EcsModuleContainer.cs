using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsModuleContainer
    {
        bool Enabled { get; }

        void Initialize(EcsWorld world);
        
        void AddFeatures(IEcsFeatures features);

        void OnInstall();
        void OnUninstall();

        EcsWorld GetWorld();
        EcsSystemsGroup GetSystemsGroup();

        IEnumerable<IEcsSystem> GetAllSystems();
        IEcsInjector GetInjector();

        void Enable();
        void Disable();
    }
    
    public sealed class EcsModuleContainer : IEcsModuleContainer
    {
        public bool Enabled { get; private set; } = true;

        private readonly List<IEcsOnInstallFeature> _installFeatures = new();
        private readonly List<IEcsOnUninstallFeature> _uninstallFeatures = new();
        private readonly List<IEcsUpdateFeature> _updateFeatures = new();
        private readonly List<IEcsLateUpdateFeature> _lateUpdateFeatures = new();
        private readonly List<IEcsFixedUpdateFeature> _fixedUpdateFeatures = new();
        private readonly List<IEcsInjectionFeature> _injectionFeatures = new();
        private readonly IEcsInjector _injector;

        private EcsWorld _world;
        private EcsSystemsGroup _systemsGroup;

        private bool _initialized;

        public EcsModuleContainer()
        {
            _injector = new EcsInjector();
        }
        
        public void Initialize(EcsWorld ecsWorld)
        {
            if (_initialized)
                throw new Exception("EcsModule can't initialized twice");

            _world = ecsWorld;
            
            _systemsGroup = new EcsSystemsGroup
            {
                UpdateSystems = new EcsSystems(_world),
                LateUpdateSystems = new EcsSystems(_world),
                FixedUpdateSystems = new EcsSystems(_world)
            };

            foreach (var updateFeature in _updateFeatures) 
                updateFeature.SetupUpdateSystems(_systemsGroup.UpdateSystems);

            foreach (var lateUpdateFeature in _lateUpdateFeatures) 
                lateUpdateFeature.SetupLateUpdateSystems(_systemsGroup.LateUpdateSystems);

            foreach (var fixedUpdateFeature in _fixedUpdateFeatures) 
                fixedUpdateFeature.SetupFixedUpdateSystems(_systemsGroup.FixedUpdateSystems);

            foreach (var injectionFeature in _injectionFeatures) 
                injectionFeature.SetupInjector(_injector);

            _initialized = true;
        }

        public void AddFeatures(IEcsFeatures features)
        {
            foreach (var feature in features.GetFeatures())
                Add(feature);
        }

        public void OnInstall()
        {
            foreach (var installFeature in _installFeatures) 
                installFeature.OnInstall();
        }

        public void OnUninstall()
        {
            GetSystemsGroup().Destroy();
            foreach (var uninstallFeature in _uninstallFeatures) 
                uninstallFeature.OnUninstall();
        }

        public void Add(IEcsFeature feature)
        {
            if (feature is IEcsOnInstallFeature installFeature) 
                _installFeatures.Add(installFeature);

            if (feature is IEcsOnUninstallFeature uninstallFeature) 
                _uninstallFeatures.Add(uninstallFeature);
            
            if (feature is IEcsUpdateFeature updateFeature) 
                _updateFeatures.Add(updateFeature);

            if (feature is IEcsLateUpdateFeature lateUpdateFeature) 
                _lateUpdateFeatures.Add(lateUpdateFeature);

            if (feature is IEcsFixedUpdateFeature fixedUpdateFeature) 
                _fixedUpdateFeatures.Add(fixedUpdateFeature);

            if (feature is IEcsInjectionFeature injectionFeature) 
                _injectionFeatures.Add(injectionFeature);
        }
        
        public EcsWorld GetWorld()
        {
            return _world;
        }

        public EcsSystemsGroup GetSystemsGroup()
        {
            return _systemsGroup;
        }

        public IEnumerable<IEcsSystem> GetAllSystems()
        {
            return _systemsGroup.GetAllSystems();
        }

        public IEcsInjector GetInjector()
        {
            return _injector;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}