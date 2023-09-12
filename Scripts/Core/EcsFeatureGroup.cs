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

        void Enable();
        void Disable();
    }
    
    public sealed class EcsFeatureGroup : IEcsFeatureGroup
    {
        public bool Enabled { get; private set; } = true;
        public EcsWorld World { get; private set; }
        public EcsSystemsGroup SystemsGroup { get; private set; }

        private readonly List<IEcsFeature> _features;

        public EcsFeatureGroup()
        {
            _features = new List<IEcsFeature>();
        }
        
        public void Initialize(EcsWorld ecsWorld)
        {
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
            
                foreach (var system in feature.GetUpdateSystems().GetSystems())
                {
                    EcsInjector.Inject(system, this, typeof(IEcsFeatureGroup));
                    EcsInjector.Inject(system, this, typeof(EcsFeatureGroup));
                    SystemsGroup.UpdateSystems.Add(system);
                }
            
                foreach (var system in feature.GetLateUpdateSystems().GetSystems())
                {
                    EcsInjector.Inject(system, this, typeof(IEcsFeatureGroup));
                    EcsInjector.Inject(system, this, typeof(EcsFeatureGroup));
                    SystemsGroup.LateUpdateSystems.Add(system);
                }
            
                foreach (var system in feature.GetFixedUpdateSystems().GetSystems())
                {
                    EcsInjector.Inject(system, this, typeof(IEcsFeatureGroup));
                    EcsInjector.Inject(system, this, typeof(EcsFeatureGroup));
                    SystemsGroup.FixedUpdateSystems.Add(system);
                }
            }
        }

        public IEcsFeatureGroup AddFeature(IEcsFeature feature)
        {
            _features.Add(feature);
            return this;
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