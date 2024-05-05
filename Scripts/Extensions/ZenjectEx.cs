using System;
using Leopotam.EcsLite;
using Zenject;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class ZenjectEx
    {
        public static void BindNewEcsWorldFor<T>(this DiContainer binder) where T : IEcsModule
        {
            binder.BindInterfacesAndSelfTo<EcsWorld>().AsSingle().NonLazy();
            binder.WithEcsRunnerFor<T>().NonLazy();
        }
        
        private static ConditionCopyNonLazyBinder WithEcsRunnerFor<T>(this DiContainer binder) where T : IEcsModule
        {
            return binder.BindInterfacesAndSelfTo<EcsRunner>().WithEcsModule<T>();
        }

        private static ConditionCopyNonLazyBinder WithEcsModule<T>(this ScopeConcreteIdArgConditionCopyNonLazyBinder binder) where T : IEcsModule
        {
            return binder.AsSingle().OnInstantiated((context, ecsManager) =>
            {
                if (ecsManager is EcsRunner manager)
                    manager.InstallModule(context.Container.Instantiate<T>());
                else
                    throw new Exception("EcsManager is not found in the container.");
            });
        }
    }
}