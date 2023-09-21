using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
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
            EcsInjection.Inject(system, _feature, typeof(IEcsFeature));
            EcsInjection.Inject(system, _feature, typeof(EcsFeature));
            EcsInjection.Inject(system, _feature, _feature.GetType());
            _systems.Add(system);
            return this;
        }

        public EcsFeature GetFeature() => _feature;
        public List<IEcsSystem> GetSystems() => _systems;
    }
}