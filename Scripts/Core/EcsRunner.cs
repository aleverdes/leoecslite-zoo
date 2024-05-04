using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using Zenject;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsRunner : ITickable, ILateTickable, IFixedTickable, IDisposable
    {
        void InstallModule(IEcsModule moduleInstaller);
        void UninstallModule(IEcsModule moduleContainer);
    }
    
    public class EcsRunner : IEcsRunner
    {
        protected readonly EcsWorld World;
        protected readonly Dictionary<IEcsModule, IEcsModuleContainer> Modules = new();
        
        public EcsRunner(EcsWorld ecsWorld)
        {
            World = ecsWorld;
        }

        public virtual void Tick()
        {
            foreach (var (_, ecsModuleContainer) in Modules)
                ecsModuleContainer.GetSystemsGroup().GetUpdateSystems().Run();
        }

        public virtual void LateTick()
        {
            foreach (var (_, ecsModuleContainer) in Modules)
                ecsModuleContainer.GetSystemsGroup().GetLateUpdateSystems().Run();
        }

        public virtual void FixedTick()
        {
            foreach (var (_, ecsModuleContainer) in Modules)
                ecsModuleContainer.GetSystemsGroup().GetFixedUpdateSystems().Run();
        }

        public virtual void Dispose()
        {
            foreach (var (_, ecsModuleContainer) in Modules)
                ecsModuleContainer.GetSystemsGroup().Destroy();
        }

        public virtual void InstallModule(IEcsModule module)
        {
            var moduleContainer = new EcsModuleContainer();
            moduleContainer.AddFeatures(module.AddFeatures(new EcsFeatures()));
            moduleContainer.Initialize(World);
            Modules.Add(module, moduleContainer);
            foreach (var system in moduleContainer.GetAllSystems())
            {
                EcsInjectionUtils.Inject(system, World, typeof(EcsWorld));
                EcsInjectionUtils.InjectPools(system, World);
                EcsInjectionUtils.InjectQueries(system, World);
            }
            moduleContainer.GetSystemsGroup().Init();
        }

        public virtual void UninstallModule(IEcsModule moduleContainer)
        {
            Modules.Remove(moduleContainer);
        }
    }
}