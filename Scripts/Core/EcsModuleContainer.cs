using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsModuleContainer
    {
        void Initialize(EcsWorld world);
        
        void AddFeatures(IEcsFeatures features);
        EcsWorld GetWorld();
        EcsSystemsGroup GetSystemsGroup();

        IEnumerable<IEcsSystem> GetAllSystems();
    }
    
    public sealed class EcsModuleContainer : IEcsModuleContainer
    {
        private readonly List<IEcsUpdateFeature> _updateFeatures = new();
        private readonly List<IEcsLateUpdateFeature> _lateUpdateFeatures = new();
        private readonly List<IEcsFixedUpdateFeature> _fixedUpdateFeatures = new();

        private EcsWorld _world;
        private EcsSystemsGroup _systemsGroup;

        private bool _initialized;

        public void Initialize(EcsWorld ecsWorld)
        {
            if (_initialized)
                throw new Exception("EcsModule can't initialized twice");

            _world = ecsWorld;
            
            var updateSystems = new EcsSystems(_world);
            var lateUpdateSystems = new EcsSystems(_world);
            var fixedUpdateSystems = new EcsSystems(_world);
            
            _systemsGroup = new EcsSystemsGroup(updateSystems, lateUpdateSystems, fixedUpdateSystems);

            foreach (var updateFeature in _updateFeatures) 
                updateFeature.SetupUpdateSystems(updateSystems);

            foreach (var lateUpdateFeature in _lateUpdateFeatures) 
                lateUpdateFeature.SetupLateUpdateSystems(lateUpdateSystems);

            foreach (var fixedUpdateFeature in _fixedUpdateFeatures) 
                fixedUpdateFeature.SetupFixedUpdateSystems(fixedUpdateSystems);

            _initialized = true;
        }

        public void AddFeatures(IEcsFeatures features)
        {
            foreach (var feature in features.GetFeatures())
                Add(feature);
        }

        private void Add(IEcsFeature feature)
        {
            if (feature is IEcsUpdateFeature updateFeature) 
                _updateFeatures.Add(updateFeature);

            if (feature is IEcsLateUpdateFeature lateUpdateFeature) 
                _lateUpdateFeatures.Add(lateUpdateFeature);

            if (feature is IEcsFixedUpdateFeature fixedUpdateFeature) 
                _fixedUpdateFeatures.Add(fixedUpdateFeature);
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
    }
}