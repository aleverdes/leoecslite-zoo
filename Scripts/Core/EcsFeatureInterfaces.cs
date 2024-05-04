using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsUpdateFeature : IEcsFeature
    {
        void SetupUpdateSystems(IEcsSystems systems);
    }

    public interface IEcsLateUpdateFeature : IEcsFeature
    {
        void SetupLateUpdateSystems(IEcsSystems systems);
    }

    public interface IEcsFixedUpdateFeature : IEcsFeature
    {
        void SetupFixedUpdateSystems(IEcsSystems systems);
    }

    public interface IEcsFeature
    {
    }
}