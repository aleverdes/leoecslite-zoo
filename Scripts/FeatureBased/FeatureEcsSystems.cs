using System;
using Leopotam.EcsLite;

namespace AffenCode
{
    public sealed class FeatureEcsSystems
    {
        private readonly IEcsSystems _updateSystems;
        private readonly IEcsSystems _lateUpdateSystems;
        private readonly IEcsSystems _fixedUpdateSystems;

        public FeatureEcsSystems(IEcsSystems update, IEcsSystems lateUpdate, IEcsSystems fixedUpdate)
        {
            _updateSystems = update;
            _lateUpdateSystems = lateUpdate;
            _fixedUpdateSystems = fixedUpdate;
        }
        
        public FeatureEcsSystems Add(IEcsFeature feature)
        {
            feature.Update(_updateSystems);
            feature.LateUpdate(_lateUpdateSystems);
            feature.FixedUpdate(_fixedUpdateSystems);
            return this;
        }

        public FeatureEcsSystems Add(IEcsSystem system, SystemType systemType)
        {
            switch (systemType)
            {
                case SystemType.Update:
                    _updateSystems.Add(system);
                    break;
                case SystemType.LateUpdate:
                    _lateUpdateSystems.Add(system);
                    break;
                case SystemType.FixedUpdate:
                    _fixedUpdateSystems.Add(system);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(systemType), systemType, null);
            }

            return this;
        }
    }
}