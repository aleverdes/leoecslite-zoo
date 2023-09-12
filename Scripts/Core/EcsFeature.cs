using System;
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

        IEnumerable<EcsFeatureInjectionInfo> GetInjections();

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
        private readonly EcsFeatureInjections _injections;

        public EcsFeature()
        {
            _updateSystems = new EcsFeatureSystems(this);
            _lateUpdateSystems = new EcsFeatureSystems(this);
            _fixedUpdateSystems = new EcsFeatureSystems(this);
            _injections = new EcsFeatureInjections(this);
            Enabled = true;
        }

        public void Setup()
        {
            SetupUpdateSystems(GetUpdateSystems());
            SetupLateUpdateSystems(GetLateUpdateSystems());
            SetupFixedUpdateSystems(GetFixedUpdateSystems());
            RegisterInjections(_injections);
        }

        protected abstract void SetupUpdateSystems(EcsFeatureSystems ecsFeatureSystems);
        protected abstract void SetupLateUpdateSystems(EcsFeatureSystems ecsFeatureSystems);
        protected abstract void SetupFixedUpdateSystems(EcsFeatureSystems ecsFeatureSystems);

        protected virtual void RegisterInjections(EcsFeatureInjections ecsFeatureInjections)
        {
        }

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

        public IEnumerable<EcsFeatureInjectionInfo> GetInjections()
        {
            return _injections.GetInjections();
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