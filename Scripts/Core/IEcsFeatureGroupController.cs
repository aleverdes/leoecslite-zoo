namespace AffenCode
{
    public abstract class EcsFeatureGroupController
    {
        private IEcsFeatureGroup _featureGroup;

        public void Initialize()
        {
            _featureGroup = CreateFeatureGroup();
        }

        protected abstract IEcsFeatureGroup CreateFeatureGroup();

        public IEcsFeatureGroup GetFeatureGroup() => _featureGroup;
    }
}