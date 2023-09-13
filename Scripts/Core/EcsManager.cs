using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leopotam.EcsLite;
using Debug = UnityEngine.Debug;

namespace AffenCode
{
    public interface IEcsManager
    {
        void AddInjector(IEcsInjector injector);
        void SetWorld(EcsWorld ecsWorld);

        void Update();
        void LateUpdate();
        void FixedUpdate();

        void Destroy();

        IEcsModule InstallModule(IEcsModuleInstaller moduleInstaller);
        void UninstallModule(IEcsModule module);
    }
    
    public sealed class EcsManager : IEcsManager
    {
        private readonly HashSet<IEcsModule> _modules = new HashSet<IEcsModule>();
        private readonly HashSet<IEcsInjector> _injectors = new HashSet<IEcsInjector>();

        private readonly HashSet<EcsFeatureSystemInfo> _systems = new HashSet<EcsFeatureSystemInfo>();
        private readonly HashSet<EcsFeatureInjectionInfo> _injections = new HashSet<EcsFeatureInjectionInfo>();

        private EcsWorld _world;
        
        private Stopwatch _addFeatureGroupStopwatch;

        public void AddInjector(IEcsInjector injector)
        {
            _injectors.Add(injector);

            foreach (var systemInfo in _systems)
            {
                injector.ExecuteInjection(systemInfo.System, _world);
            }
        }

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
            _addFeatureGroupStopwatch = Stopwatch.StartNew();
            
            var module = moduleInstaller.Install();

            Debug.Log($"EcsManager - Installed ECS Module\n{_addFeatureGroupStopwatch.Elapsed}");
            
            module.Initialize(_world);

            Debug.Log($"EcsManager - Initialized ECS Module\n{_addFeatureGroupStopwatch.Elapsed}");
            
            foreach (var systemInfo in module.GetAllSystems())
            {
                _systems.Add(systemInfo);
            }
            
            Debug.Log($"EcsManager - Added ECS Module info about systems\n{_addFeatureGroupStopwatch.Elapsed}");

            foreach (var injectionInfo in module.GetAllInjections())
            {
                _injections.Add(injectionInfo);
            }
            
            Debug.Log($"EcsManager - Added ECS Module info about injections\n{_addFeatureGroupStopwatch.Elapsed}");

            _modules.Add(module);
            
            Debug.Log($"EcsManager - Started injecting into ECS Module\n{_addFeatureGroupStopwatch.Elapsed}");

            RebuildInjections();
            
            Debug.Log($"EcsManager - Finished injecting into ECS Module\n{_addFeatureGroupStopwatch.Elapsed}");

            module.GetSystemsGroup().Init();
            
            Debug.Log($"EcsManager - Initialized ECS Module systems\n{_addFeatureGroupStopwatch.Elapsed}");
            
            _addFeatureGroupStopwatch.Stop();
            _addFeatureGroupStopwatch = null;

            return module;
        }

        public void UninstallModule(IEcsModule module)
        {
            foreach (var system in _systems.Where(systemInfo => systemInfo.Module == module).ToArray())
            {
                _systems.Remove(system);
            }
            
            module.GetSystemsGroup().Destroy();
            
            _modules.Remove(module);
        }

        private void RebuildInjections()
        {
            foreach (var systemInfo in _systems)
            {
                foreach (var injector in _injectors)
                {
                    injector.ExecuteInjection(systemInfo.System, _world);
                }

                foreach (var injection in _injections)
                {
                    EcsInjection.Inject(systemInfo.System, injection.Object, injection.Types);
                }
            }
            
            Debug.Log($"EcsManager - RebuildInjections — Finished Systems injection\n{_addFeatureGroupStopwatch.Elapsed}");

            foreach (var injection in _injections)
            {
                foreach (var injector in _injectors)
                {
                    EcsInjection.Inject(injection.Object, _world, typeof(EcsWorld));
            
                    foreach (var (injectionType, injectionObject) in injector.GetInjectionObjects())
                    {
                        EcsInjection.Inject(injection.Object, injectionObject, injectionType);
                    }

                    EcsInjection.InjectPools(injection.Object, _world);
                }

                foreach (var injectionToInject in _injections)
                {
                    EcsInjection.Inject(injection.Object, injectionToInject.Object, injectionToInject.Types);
                }
            }
            
            Debug.Log($"RebuildInjections — Finished Injections injection\n{_addFeatureGroupStopwatch.Elapsed}");
        }
    }
}