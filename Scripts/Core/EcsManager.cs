using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leopotam.EcsLite;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
    
    public sealed class EcsManager : IEcsManager
    {
        private readonly HashSet<IEcsModule> _modules = new();
        private readonly HashSet<IEcsInjector> _injectors = new();

        private EcsWorld _world;

        public void SetWorld(EcsWorld ecsWorld)
        {
            _world = ecsWorld;
        }

        public void Update()
        {
            foreach (var systemsContext in _modules)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.GetSystemsGroup().UpdateSystems.Run();
                }
            }
        }

        public void LateUpdate()
        {
            foreach (var systemsContext in _modules)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.GetSystemsGroup().LateUpdateSystems.Run();
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (var systemsContext in _modules)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.GetSystemsGroup().FixedUpdateSystems.Run();
                }
            }
        }

        public void Destroy()
        {
            foreach (var systemsContext in _modules)
            {
                systemsContext.GetSystemsGroup().Destroy();
            }
        }
        
        public IEcsModule InstallModule(IEcsModuleInstaller moduleInstaller)
        {
            var module = moduleInstaller.Install();
            module.Initialize(_world);
            _modules.Add(module);
            RebuildInjections();
            module.GetSystemsGroup().Init();
            return module;
        }

        public void UninstallModule(IEcsModule module)
        {
            module.GetSystemsGroup().Destroy();
            _modules.Remove(module);
        }
        
        public void AddInjector(IEcsInjector injector)
        {
            _injectors.Add(injector);
            RebuildInjections();
        }

        private void RebuildInjections()
        {
            foreach (var module in _modules)
            {
                foreach (var system in module.GetAllSystems())
                {
                    Inject(system);
                }

                foreach (var injectionObject in module.GetInjector().GetInjectionObjects().Values.ToHashSet())
                {
                    Inject(injectionObject);
                }
                
                void Inject(object target)
                {
                    EcsInjection.Inject(target, _world, typeof(EcsWorld));
                    foreach (var injector in _injectors)
                    {
                        injector.ExecuteInjection(target);
                    }
                    EcsInjection.InjectPools(target, _world);
                    EcsInjection.InjectQueries(target, _world);
                    module.GetInjector().ExecuteInjection(target);
                }
            }
        }
    }
}