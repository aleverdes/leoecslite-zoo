using System;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    [Obsolete("Use separate interfaces instead of this")]
    public interface IEcsFeature : IEcsUpdateFeature, IEcsLateUpdateFeature, IEcsFixedUpdateFeature, IEcsInjectionFeature
    {
    }
    
    public interface IEcsUpdateFeature : IEcsModulePart
    {
        void SetupUpdateSystems(IEcsSystems systems);
    }

    public interface IEcsLateUpdateFeature : IEcsModulePart
    {
        void SetupLateUpdateSystems(IEcsSystems systems);
    }

    public interface IEcsFixedUpdateFeature : IEcsModulePart
    {
        void SetupFixedUpdateSystems(IEcsSystems systems);
    }

    public interface IEcsInjectionFeature : IEcsModulePart
    {
        void SetupInjector(IEcsInjector injector);
    }

    public interface IEcsModulePart
    {
    }
}