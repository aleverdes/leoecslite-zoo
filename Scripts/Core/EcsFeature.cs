namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsFeature
    {
        bool Enabled { get; }
        
        EcsFeatureSystems GetUpdateSystems();
        EcsFeatureSystems GetLateUpdateSystems();
        EcsFeatureSystems GetFixedUpdateSystems();

        IEcsInjector GetInjector();

        void Setup();
        void Enable();
        void Disable();
    }

    public abstract class EcsFeature : IEcsFeature
    {
        public bool Enabled { get; protected set; }

        private readonly EcsFeatureSystems _updateSystems;
        private readonly EcsFeatureSystems _lateUpdateSystems;
        private readonly EcsFeatureSystems _fixedUpdateSystems;
        private readonly EcsInjector _injector;

        public EcsFeature()
        {
            _updateSystems = new EcsFeatureSystems(this);
            _lateUpdateSystems = new EcsFeatureSystems(this);
            _fixedUpdateSystems = new EcsFeatureSystems(this);
            _injector = new EcsInjector();
            Enabled = true;
        }

        public void Setup()
        {
            SetupUpdateSystems(GetUpdateSystems());
            SetupLateUpdateSystems(GetLateUpdateSystems());
            SetupFixedUpdateSystems(GetFixedUpdateSystems());
            RegisterInjections(_injector);
        }

        protected abstract void SetupUpdateSystems(EcsFeatureSystems ecsFeatureSystems);
        protected abstract void SetupLateUpdateSystems(EcsFeatureSystems ecsFeatureSystems);
        protected abstract void SetupFixedUpdateSystems(EcsFeatureSystems ecsFeatureSystems);

        protected virtual void RegisterInjections(IEcsInjector injector)
        {
        }

        public EcsFeatureSystems GetUpdateSystems()
        {
            return _updateSystems;
        }

        public EcsFeatureSystems GetLateUpdateSystems()
        {
            return _lateUpdateSystems;
        }

        public EcsFeatureSystems GetFixedUpdateSystems()
        {
            return _fixedUpdateSystems;
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