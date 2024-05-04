using System;
using Zenject;

namespace AleVerDes.LeoEcsLiteZoo
{
    public static class ZenjectEx
    {
        public static ConditionCopyNonLazyBinder WithEcsModule<T>(this FromBinderNonGeneric binder) where T : IEcsModule
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