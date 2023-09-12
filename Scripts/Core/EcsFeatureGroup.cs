using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AffenCode
{
    public interface IEcsFeatureGroup
    {
        bool Enabled { get; }
        
        EcsWorld World { get; }
        EcsSystemsGroup SystemsGroup { get; }

        void Initialize(EcsWorld world);
        
        IEcsFeatureGroup AddFeature(IEcsFeature feature);

        IEnumerable<EcsFeatureSystemInfo> GetSystems();
        IEnumerable<EcsFeatureInjectionInfo> GetInjections();

        void Enable();
        void Disable();
    }
    
    public sealed class EcsFeatureGroup : IEcsFeatureGroup
    {
        public bool Enabled { get; private set; } = true;
        public EcsWorld World { get; private set; }
        public EcsSystemsGroup SystemsGroup { get; private set; }

        private readonly List<IEcsFeature> _features;
        private readonly List<EcsFeatureSystemInfo> _systems;
        private readonly List<EcsFeatureInjectionInfo> _injections;

        private bool _initialized;

        public EcsFeatureGroup()
        {
            _features = new List<IEcsFeature>();
            _systems = new List<EcsFeatureSystemInfo>();
            _injections = new List<EcsFeatureInjectionInfo>();
        }
        
        public void Initialize(EcsWorld ecsWorld)
        {
            if (_initialized)
            {
                throw new Exception("EcsFeatureGroup can't initialized twice");
            }

            World = ecsWorld;
            
            SystemsGroup = new EcsSystemsGroup
            {
                UpdateSystems = new EcsSystems(World),
                LateUpdateSystems = new EcsSystems(World),
                FixedUpdateSystems = new EcsSystems(World)
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
                    SystemsGroup.UpdateSystems.Add(system);
                    SystemPostAdd(system);
                }
            
                foreach (var system in feature.GetLateUpdateSystems().GetSystems())
                {
                    SystemsGroup.LateUpdateSystems.Add(system);
                    SystemPostAdd(system);
                }
            
                foreach (var system in feature.GetFixedUpdateSystems().GetSystems())
                {
                    SystemsGroup.FixedUpdateSystems.Add(system);
                    SystemPostAdd(system);
                }

                void SystemPostAdd(IEcsSystem system)
                {
                    EcsInjector.Inject(system, this, typeof(IEcsFeatureGroup));
                    EcsInjector.Inject(system, this, typeof(EcsFeatureGroup));
                    _systems.Add(new EcsFeatureSystemInfo()
                    {
                        FeatureGroup = this,
                        Feature = feature,
                        System = system
                    });
                }
            }
        }

        public IEcsFeatureGroup AddFeature(IEcsFeature feature)
        {
            _features.Add(feature);
            return this;
        }

        public IEnumerable<EcsFeatureSystemInfo> GetSystems()
        {
            return _systems;
        }

        public IEnumerable<EcsFeatureInjectionInfo> GetInjections()
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