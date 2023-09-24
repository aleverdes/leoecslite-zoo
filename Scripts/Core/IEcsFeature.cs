using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsFeature
    {
        void SetupUpdateSystems(IEcsSystems systems);
        void SetupLateUpdateSystems(IEcsSystems systems);
        void SetupFixedUpdateSystems(IEcsSystems systems);
        void SetupInjector(IEcsInjector injector);
    }
}