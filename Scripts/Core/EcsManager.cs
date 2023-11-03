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

        IEcsModule InstallModule(IEcsModuleInstaller moduleInstaller);
        void UninstallModule(IEcsModule module);
        
        void AddInjector(IEcsInjector injector);
    }
    
    public class EcsManager : IEcsManager
    {
        protected readonly HashSet<IEcsModule> Modules = new();
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
                {
                    systemsContext.GetSystemsGroup().UpdateSystems.Run();
                }
            }
        }

        public virtual void LateUpdate()
        {
            foreach (var systemsContext in Modules)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.GetSystemsGroup().LateUpdateSystems.Run();
                }
            }
        }

        public virtual void FixedUpdate()
        {
            foreach (var systemsContext in Modules)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.GetSystemsGroup().FixedUpdateSystems.Run();
                }
            }
        }

        public virtual void Destroy()
        {
            foreach (var systemsContext in Modules)
            {
                systemsContext.GetSystemsGroup().Destroy();
            }
        }
        
        public virtual IEcsModule InstallModule(IEcsModuleInstaller moduleInstaller)
        {
            var module = moduleInstaller.Install();
            module.Initialize(World);
            Modules.Add(module);
            Injectors.Add(module.GetInjector());
            RebuildInjections();
            module.GetSystemsGroup().Init();
            return module;
        }

        public virtual void UninstallModule(IEcsModule module)
        {
            module.GetSystemsGroup().Destroy();
            Modules.Remove(module);
        }
        
        public virtual void AddInjector(IEcsInjector injector)
        {
            Injectors.Add(injector);
            RebuildInjections();
        }

        protected virtual void RebuildInjections()
        {
            foreach (var module in Modules)
            {
                foreach (var system in module.GetAllSystems())
                {
                    Inject(system);
                }

                foreach (var injector in Injectors)
                {
                    foreach (var injectionObject in injector.GetInjectionObjects().Values)
                    {
#if UNITY_5_3_OR_NEWER
                        if (injectionObject is UnityEngine.Object)
                            continue;
#endif
                        Inject(injectionObject);
                    }
                }
                
                void Inject(object target)
                {
                    EcsInjection.Inject(target, World, typeof(EcsWorld));
                    foreach (var injector in Injectors)
                    {
                        injector.ExecuteInjection(target);
                    }
                    EcsInjection.InjectPools(target, World);
                    EcsInjection.InjectQueries(target, World);
                    module.GetInjector().ExecuteInjection(target);
                }
            }
        }
    }
}