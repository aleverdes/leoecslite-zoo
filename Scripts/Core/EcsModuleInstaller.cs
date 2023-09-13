namespace AffenCode
{
    public abstract class EcsModuleInstaller
    {
        private IEcsModule _ecsModule;

        public void Initialize()
        {
            _ecsModule = Install();
        }

        protected abstract IEcsModule Install();

        public IEcsModule GetEcsModule() => _ecsModule;
    }
}