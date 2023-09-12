namespace AffenCode
{
    public abstract class EcsFeatureGroupController
    {
        private EcsFeatureGroup _featureGroup;

        public void Initialize()
        {
            _featureGroup = CreateFeatureGroup();
        }

        protected abstract EcsFeatureGroup CreateFeatureGroup();

        public EcsFeatureGroup GetFeatureGroup() => _featureGroup;
    }
}