using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsManager
    {
        void SetWorld(EcsWorld ecsWorld);

        void Update();
        void LateUpdate();
        void FixedUpdate();

        void Destroy();

        IEcsModuleContainer InstallModule(IEcsModuleInstaller moduleInstaller);
        void UninstallModule(IEcsModuleContainer moduleContainer);
        
        void AddInjector(IEcsInjector injector);
        IEnumerable<IEcsInjector> GetInjectors();
    }
    
    public class EcsManager : IEcsManager, IEcsInjectionContainer
    {
        protected readonly HashSet<IEcsModuleContainer> Modules = new();
        protected readonly HashSet<IEcsInjector> Injectors = new();

        protected EcsWorld World;

        public virtual void SetWorld(EcsWorld ecsWorld)
        {
            World = ecsWorld;
        }

        public virtual void Update()
        {
            foreach (var systemsContext in Modules)
            {
                if (systemsContext.Enabled) 
                    systemsContext.GetSystemsGroup().UpdateSystems.Run();
            }
        }

        public virtual void LateUpdate()
        {
            foreach (var systemsContext in Modules)
            {
                if (systemsContext.Enabled) 
                    systemsContext.GetSystemsGroup().LateUpdateSystems.Run();
            }
        }

        public virtual void FixedUpdate()
        {
            foreach (var systemsContext in Modules)
            {
                if (systemsContext.Enabled) 
                    systemsContext.GetSystemsGroup().FixedUpdateSystems.Run();
            }
        }

        public virtual void Destroy()
        {
            foreach (var systemsContext in Modules) 
                systemsContext.GetSystemsGroup().Destroy();
        }
        
        public virtual IEcsModuleContainer InstallModule(IEcsModuleInstaller moduleInstaller)
        {
            var module = moduleInstaller.Install();
            module.Initialize(World);
            Modules.Add(module);
            Injectors.Add(module.GetInjector());
            RebuildInjections();
            module.OnInstall();
            module.GetSystemsGroup().Init();
            return module;
        }

        public virtual void UninstallModule(IEcsModuleContainer moduleContainer)
        {
            moduleContainer.OnUninstall();
            Modules.Remove(moduleContainer);
        }
        
        public virtual void AddInjector(IEcsInjector injector)
        {
            Injectors.Add(injector);
            RebuildInjections();
        }
        
        public virtual IEnumerable<IEcsInjector> GetInjectors()
        {
            return Injectors;
        }

        protected virtual void RebuildInjections()
        {
            foreach (var module in Modules)
            {
                foreach (var system in module.GetAllSystems()) 
                    Inject(system);

                foreach (var injector in Injectors)
                foreach (var injectionObject in injector.GetInjectionObjects().Values)
                {
#if UNITY_5_3_OR_NEWER
                    if (injectionObject is UnityEngine.Object)
                        continue;
#endif
                    Inject(injectionObject);
                }

                void Inject(object target)
                {
                    EcsInjectionUtils.Inject(target, World, typeof(EcsWorld));
                    foreach (var injector in Injectors) 
                        injector.ExecuteInjection(target);
                    EcsInjectionUtils.InjectPools(target, World);
                    EcsInjectionUtils.InjectQueries(target, World);
                    module.GetInjector().ExecuteInjection(target);
                }
            }
        }
    }
}