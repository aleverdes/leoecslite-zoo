using System;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsOnInstallFeature : IEcsFeature
    {
        void OnInstall();
    }
    
    public interface IEcsOnUninstallFeature : IEcsFeature
    {
        void OnUninstall();
    }
    
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

    public interface IEcsInjectionFeature : IEcsFeature
    {
        void SetupInjector(IEcsInjector injector);
    }

    public interface IEcsFeature
    {
    }
}