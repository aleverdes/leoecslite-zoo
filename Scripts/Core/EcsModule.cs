using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AffenCode
{
    public interface IEcsModule
    {
        bool Enabled { get; }

        void Initialize(EcsWorld world);
        
        IEcsModule AddFeature(IEcsFeature feature);

        EcsWorld GetWorld();
        EcsSystemsGroup GetSystemsGroup();

        IEnumerable<EcsFeatureSystemInfo> GetAllSystems();
        IEnumerable<EcsFeatureInjectionInfo> GetAllInjections();

        void Enable();
        void Disable();
    }
    
    public sealed class EcsModule : IEcsModule
    {
        public bool Enabled { get; private set; } = true;

        private readonly List<IEcsFeature> _features;
        private readonly List<EcsFeatureSystemInfo> _systems;
        private readonly List<EcsFeatureInjectionInfo> _injections;

        private EcsWorld _world;
        private EcsSystemsGroup _systemsGroup;

        private bool _initialized;

        public EcsModule()
        {
            _features = new List<IEcsFeature>();
            _systems = new List<EcsFeatureSystemInfo>();
            _injections = new List<EcsFeatureInjectionInfo>();
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
                feature.Setup();

                foreach (var injectionInfo in feature.GetInjections())
                {
                    _injections.Add(injectionInfo);
                }
            
                foreach (var system in feature.GetUpdateSystems().GetSystems())
                {
                    _systemsGroup.UpdateSystems.Add(system);
                    SystemPostAdd(system);
                }
            
                foreach (var system in feature.GetLateUpdateSystems().GetSystems())
                {
                    _systemsGroup.LateUpdateSystems.Add(system);
                    SystemPostAdd(system);
                }
            
                foreach (var system in feature.GetFixedUpdateSystems().GetSystems())
                {
                    _systemsGroup.FixedUpdateSystems.Add(system);
                    SystemPostAdd(system);
                }

                void SystemPostAdd(IEcsSystem system)
                {
                    EcsInjection.Inject(system, this, typeof(IEcsModule));
                    EcsInjection.Inject(system, this, typeof(EcsModule));
                    _systems.Add(new EcsFeatureSystemInfo()
                    {
                        Module = this,
                        Feature = feature,
                        System = system
                    });
                }
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

        public IEnumerable<EcsFeatureSystemInfo> GetAllSystems()
        {
            return _systems;
        }

        public IEnumerable<EcsFeatureInjectionInfo> GetAllInjections()
        {
            return _injections;
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