using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AffenCode
{
    public interface IEcsFeature
    {
        bool Enabled { get; }
        
        EcsFeatureSystems GetUpdateSystems();
        EcsFeatureSystems GetLateUpdateSystems();
        EcsFeatureSystems GetFixedUpdateSystems();

        void Setup();
        void Enable();
        void Disable();
    }
    
    public abstract class EcsFeature : IEcsFeature
    {
        public bool Enabled { get; protected set; }

        private readonly EcsFeatureSystems _updateSystems;
        private readonly EcsFeatureSystems _lateUpdateSystems;
        private readonly EcsFeatureSystems _fixedUpdateSystems;

        public EcsFeature()
        {
            _updateSystems = new EcsFeatureSystems(this);
            _lateUpdateSystems = new EcsFeatureSystems(this);
            _fixedUpdateSystems = new EcsFeatureSystems(this);
            Enabled = true;
        }

        public void Setup()
        {
            SetupUpdateSystems(GetUpdateSystems());
            SetupLateUpdateSystems(GetLateUpdateSystems());
            SetupFixedUpdateSystems(GetFixedUpdateSystems());
        }

        protected abstract void SetupUpdateSystems(EcsFeatureSystems ecsFeatureSystems);
        protected abstract void SetupLateUpdateSystems(EcsFeatureSystems ecsFeatureSystems);
        protected abstract void SetupFixedUpdateSystems(EcsFeatureSystems ecsFeatureSystems);

        public EcsFeatureSystems GetUpdateSystems()
        {
            return _updateSystems;
        }

        public EcsFeatureSystems GetLateUpdateSystems()
        {
            return _lateUpdateSystems;
        }

        public EcsFeatureSystems GetFixedUpdateSystems()
        {
            return _fixedUpdateSystems;
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

    public class EcsFeatureSystems
    {
        private readonly EcsFeature _feature;
        private readonly List<IEcsSystem> _systems = new List<IEcsSystem>();

        public EcsFeatureSystems(EcsFeature feature)
        {
            _feature = feature;
        }

        public EcsFeatureSystems Add(IEcsSystem system)
        {
            EcsInjector.Inject(system, _feature, typeof(IEcsFeature));
            EcsInjector.Inject(system, _feature, typeof(EcsFeature));
            EcsInjector.Inject(system, _feature, _feature.GetType());
            _systems.Add(system);
            return this;
        }

        public EcsFeature GetFeature() => _feature;
        public List<IEcsSystem> GetSystems() => _systems;
    }
}