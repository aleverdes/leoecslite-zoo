using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsModule
    {
        bool Enabled { get; }

        void Initialize(EcsWorld world);
        
        IEcsModule Add(IEcsModulePart modulePart);

        EcsWorld GetWorld();
        EcsSystemsGroup GetSystemsGroup();

        IEnumerable<IEcsSystem> GetAllSystems();
        IEcsInjector GetInjector();

        void Enable();
        void Disable();
    }
    
    public sealed class EcsModule : IEcsModule
    {
        public bool Enabled { get; private set; } = true;

        private readonly List<IEcsUpdateFeature> _updateFeatures = new();
        private readonly List<IEcsLateUpdateFeature> _lateUpdateFeatures = new();
        private readonly List<IEcsFixedUpdateFeature> _fixedUpdateFeatures = new();
        private readonly List<IEcsInjectionFeature> _injectionFeatures = new();
        private readonly IEcsInjector _injector;

        private EcsWorld _world;
        private EcsSystemsGroup _systemsGroup;

        private bool _initialized;

        public EcsModule()
        {
            _injector = new EcsInjector();
        }
        
        public void Initialize(EcsWorld ecsWorld)
        {
            if (_initialized)
            {
                throw new Exception("EcsModule can't initialized twice");
            }

            _world = ecsWorld;
            
            _systemsGroup = new EcsSystemsGroup
            {
                UpdateSystems = new EcsSystems(_world),
                LateUpdateSystems = new EcsSystems(_world),
                FixedUpdateSystems = new EcsSystems(_world)
            };

            foreach (var updateFeature in _updateFeatures)
            {
                updateFeature.SetupUpdateSystems(_systemsGroup.UpdateSystems);
            }

            foreach (var lateUpdateFeature in _lateUpdateFeatures)
            {
                lateUpdateFeature.SetupLateUpdateSystems(_systemsGroup.LateUpdateSystems);
            }

            foreach (var fixedUpdateFeature in _fixedUpdateFeatures)
            {
                fixedUpdateFeature.SetupFixedUpdateSystems(_systemsGroup.FixedUpdateSystems);
            }

            foreach (var injectionFeature in _injectionFeatures)
            {
                injectionFeature.SetupInjector(_injector);
            }

            _initialized = true;
        }

        public IEcsModule Add(IEcsModulePart modulePart)
        {
            if (modulePart is IEcsUpdateFeature updateFeature)
            {
                _updateFeatures.Add(updateFeature);
            }
            
            if (modulePart is IEcsLateUpdateFeature lateUpdateFeature)
            {
                _lateUpdateFeatures.Add(lateUpdateFeature);
            }
            
            if (modulePart is IEcsFixedUpdateFeature fixedUpdateFeature)
            {
                _fixedUpdateFeatures.Add(fixedUpdateFeature);
            }
            
            if (modulePart is IEcsInjectionFeature injectionFeature)
            {
                _injectionFeatures.Add(injectionFeature);
            }
            
            return this;
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