using System.Collections.Generic;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsFeatures
    {
        IEcsFeatures Add(IEcsFeature feature);
        IEnumerable<IEcsFeature> GetFeatures();
    }

    public class EcsFeatures : IEcsFeatures
    {
        private readonly List<IEcsFeature> _features = new();

        public IEcsFeatures Add(IEcsFeature feature)
        {
            _features.Add(feature);
            return this;
        }
        
        public IEnumerable<IEcsFeature> GetFeatures()
        {
            return _features;
        }
    }
}