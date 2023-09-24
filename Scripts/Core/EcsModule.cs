using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsModule
    {
        bool Enabled { get; }

        void Initialize(EcsWorld world);
        
        IEcsModule AddFeature(IEcsFeature feature);

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

        private readonly List<IEcsFeature> _features;
        private readonly IEcsInjector _injector;

        private EcsWorld _world;
        private EcsSystemsGroup _systemsGroup;

        private bool _initialized;

        public EcsModule()
        {
            _features = new List<IEcsFeature>();
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

            foreach (var feature in _features)
            {
                feature.SetupUpdateSystems(_systemsGroup.UpdateSystems);
                feature.SetupLateUpdateSystems(_systemsGroup.LateUpdateSystems);
                feature.SetupFixedUpdateSystems(_systemsGroup.FixedUpdateSystems);
                feature.SetupInjector(_injector);
            }

            _initialized = true;
        }

        public IEcsModule AddFeature(IEcsFeature feature)
        {
            _features.Add(feature);
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