using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Leopotam.EcsLite;
using Debug = UnityEngine.Debug;

namespace AffenCode
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
        
        void AddInjector(IEcsInjector injector, bool isExternalInjector);
    }
    
    public sealed class EcsManager : IEcsManager
    {
        private readonly HashSet<IEcsModule> _modules = new HashSet<IEcsModule>();
        private readonly Dictionary<IEcsInjector, bool> _injectors = new Dictionary<IEcsInjector, bool>();

        private readonly HashSet<EcsFeatureSystemInfo> _systems = new HashSet<EcsFeatureSystemInfo>();

        private EcsWorld _world;
        
        private Stopwatch _installModuleStopwatch;
        private Stopwatch _rebuildInjectionsStopwatch;

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
            _installModuleStopwatch = Stopwatch.StartNew();
            
            var module = moduleInstaller.Install();

            Debug.Log($"EcsManager - Installed ECS Module\n{_installModuleStopwatch.Elapsed}");
            
            module.Initialize(_world);

            Debug.Log($"EcsManager - Initialized ECS Module\n{_installModuleStopwatch.Elapsed}");
            
            foreach (var systemInfo in module.GetAllSystems())
            {
                _systems.Add(systemInfo);
            }
            
            Debug.Log($"EcsManager - Added ECS Module info about systems\n{_installModuleStopwatch.Elapsed}");

            foreach (var injector in module.GetAllInjectors())
            {
                _injectors.Add(injector, false);
            }
            
            Debug.Log($"EcsManager - Added ECS Module info about injections\n{_installModuleStopwatch.Elapsed}");

            _modules.Add(module);
            
            Debug.Log($"EcsManager - Started injecting into ECS Module\n{_installModuleStopwatch.Elapsed}");

            RebuildInjections();
            
            Debug.Log($"EcsManager - Finished injecting into ECS Module\n{_installModuleStopwatch.Elapsed}");

            module.GetSystemsGroup().Init();
            
            Debug.Log($"EcsManager - Initialized ECS Module systems\n{_installModuleStopwatch.Elapsed}");
            
            _installModuleStopwatch.Stop();
            _installModuleStopwatch = null;

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
        
        public void AddInjector(IEcsInjector injector, bool isExternalInjector)
        {
            _injectors.Add(injector, isExternalInjector);
            RebuildInjections();
        }

        private void RebuildInjections()
        {
            _rebuildInjectionsStopwatch = Stopwatch.StartNew();
            
            foreach (var systemInfo in _systems)
            {
                foreach (var (injector, isExternalInjector) in _injectors)
                {
                    EcsInjection.Inject(systemInfo.System, _world, typeof(EcsWorld));
                    injector.ExecuteInjection(systemInfo.System);
                    EcsInjection.InjectPools(systemInfo.System, _world);
                }
            }
            
            Debug.Log($"EcsManager - RebuildInjections — Finished Systems injection\n{_rebuildInjectionsStopwatch.Elapsed}");

            foreach (var (targetObjectType, targetObject) in _injectors.Where(x => !x.Value).SelectMany(targetInjector => targetInjector.Key.GetInjectionObjects()))
            {
                EcsInjection.Inject(targetObject, _world, typeof(EcsWorld));
                    
                foreach (var (sourceInjector, isExternalInjector) in _injectors)
                {
                    sourceInjector.ExecuteInjection(targetObject);
                }
                    
                EcsInjection.InjectPools(targetObject, _world);
            }
            
            Debug.Log($"EcsManager - RebuildInjections — Finished Injections injection\n{_rebuildInjectionsStopwatch.Elapsed}");
            
            _rebuildInjectionsStopwatch.Stop();
            _rebuildInjectionsStopwatch = null;
        }
    }
}