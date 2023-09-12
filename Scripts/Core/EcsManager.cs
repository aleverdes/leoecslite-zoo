using System;
using System.Collections.Generic;
using System.Diagnostics;
using Leopotam.EcsLite;
using Debug = UnityEngine.Debug;

namespace AffenCode
{
    public sealed class EcsManager
    {
        private readonly HashSet<IEcsFeatureGroup> _featureGroups = new HashSet<IEcsFeatureGroup>();
        private readonly HashSet<EcsInjector> _injectors = new HashSet<EcsInjector>();

        private readonly HashSet<EcsFeatureSystemInfo> _systems = new HashSet<EcsFeatureSystemInfo>();
        private readonly HashSet<EcsFeatureInjectionInfo> _injections = new HashSet<EcsFeatureInjectionInfo>();

        private EcsWorld _world;
        private Stopwatch _addFeatureGroupStopwatch;

        public void AddInjector(EcsInjector injector)
        {
            _injectors.Add(injector);

            foreach (var systemsContext in _featureGroups)
            {
                injector.ExecuteInjection(systemsContext.SystemsGroup.UpdateSystems);
                injector.ExecuteInjection(systemsContext.SystemsGroup.LateUpdateSystems);
                injector.ExecuteInjection(systemsContext.SystemsGroup.FixedUpdateSystems);
            }
        }

        public void SetWorld(EcsWorld ecsWorld)
        {
            _world = ecsWorld;
        }

        public void Update()
        {
            foreach (var systemsContext in _featureGroups)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.SystemsGroup.UpdateSystems.Run();
                }
            }
        }

        public void LateUpdate()
        {
            foreach (var systemsContext in _featureGroups)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.SystemsGroup.LateUpdateSystems.Run();
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (var systemsContext in _featureGroups)
            {
                if (systemsContext.Enabled)
                {
                    systemsContext.SystemsGroup.FixedUpdateSystems.Run();
                }
            }
        }

        public void Destroy()
        {
            foreach (var systemsContext in _featureGroups)
            {
                systemsContext.SystemsGroup.Destroy();
            }
        }
        
        public void AddFeatureGroup(IEcsFeatureGroup featureGroup)
        {
            _addFeatureGroupStopwatch = Stopwatch.StartNew();
            
            featureGroup.Initialize(_world);

            Debug.Log($"EcsManager - Initialized feature group\n{_addFeatureGroupStopwatch.Elapsed}");
            
            foreach (var systemInfo in featureGroup.GetSystems())
            {
                _systems.Add(systemInfo);
            }
            
            Debug.Log($"EcsManager - Added feature group systems\n{_addFeatureGroupStopwatch.Elapsed}");

            foreach (var injectionInfo in featureGroup.GetInjections())
            {
                _injections.Add(injectionInfo);
            }
            
            Debug.Log($"EcsManager - Added feature group injections\n{_addFeatureGroupStopwatch.Elapsed}");

            _featureGroups.Add(featureGroup);
            
            Debug.Log($"EcsManager - Started injecting\n{_addFeatureGroupStopwatch.Elapsed}");

            RebuildInjections();
            
            Debug.Log($"EcsManager - Finished injecting\n{_addFeatureGroupStopwatch.Elapsed}");

            featureGroup.SystemsGroup.Init();
            
            Debug.Log($"EcsManager - Initialized systems\n{_addFeatureGroupStopwatch.Elapsed}");
            
            _addFeatureGroupStopwatch.Stop();
            _addFeatureGroupStopwatch = null;
        }

        public void RemoveFeatureGroup(EcsFeatureGroup featureGroup)
        {
            featureGroup.SystemsGroup.Destroy();

            _featureGroups.Remove(featureGroup);
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
                    EcsInjector.Inject(systemInfo.System, injection.Object, injection.Types);
                }
            }
            
            Debug.Log($"EcsManager - RebuildInjections — Finished Systems injection\n{_addFeatureGroupStopwatch.Elapsed}");

            foreach (var injection in _injections)
            {
                foreach (var injector in _injectors)
                {
                    EcsInjector.Inject(injection.Object, _world, typeof(EcsWorld));
            
                    foreach (var (injectionType, injectionObject) in injector.GetInjectedObjects())
                    {
                        EcsInjector.Inject(injection.Object, injectionObject, injectionType);
                    }

                    injector.InjectPools(injection.Object, _world);
                }

                foreach (var injectionToInject in _injections)
                {
                    EcsInjector.Inject(injection.Object, injectionToInject.Object, injectionToInject.Types);
                }
            }
            
            Debug.Log($"RebuildInjections — Finished Injections injection\n{_addFeatureGroupStopwatch.Elapsed}");
        }
    }
}