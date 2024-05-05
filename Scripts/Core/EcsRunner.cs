using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public abstract class EcsRunner
    {
        protected readonly List<EcsSystemsGroup> Systems = new();
        
        protected EcsWorld World;
        
        public virtual EcsRunner SetWorld(EcsWorld world)
        {
            World = world;
            return this;
        }

        public virtual EcsRunner AddFeature(IEcsFeature feature)
        {
            var updateSystems = new EcsSystems(World);
            var lateUpdateSystems = new EcsSystems(World);
            var fixedUpdateSystems = new EcsSystems(World);
                
            if (feature is IEcsUpdateFeature updateFeature)
                updateFeature.SetupUpdateSystems(updateSystems);
                
            if (feature is IEcsLateUpdateFeature lateUpdateFeature)
                lateUpdateFeature.SetupLateUpdateSystems(lateUpdateSystems);
                
            if (feature is IEcsFixedUpdateFeature fixedUpdateFeature)
                fixedUpdateFeature.SetupFixedUpdateSystems(fixedUpdateSystems);
                
            var systemsGroup = new EcsSystemsGroup(updateSystems, lateUpdateSystems, fixedUpdateSystems);
            Inject(systemsGroup);
            Systems.Add(systemsGroup);

            return this;
        }
        
        protected virtual void Init()
        {
            foreach (var systems in Systems)
                systems.Init();
        }

        protected virtual void Update()
        {
            foreach (var systems in Systems)
                systems.GetUpdateSystems().Run();
        }

        protected virtual void LateUpdate()
        {
            foreach (var systems in Systems)
                systems.GetLateUpdateSystems().Run();
        }

        protected virtual void FixedUpdate()
        {
            foreach (var systems in Systems)
                systems.GetFixedUpdateSystems().Run();
        }

        protected virtual void Destroy()
        {
            foreach (var systems in Systems)
                systems.Destroy();
        }

        protected virtual void Inject(EcsSystemsGroup systemsGroup)
        {
            foreach (var system in systemsGroup.GetAllSystems())
            {
                EcsInjectionUtils.Inject(system, World, typeof(EcsWorld));
                EcsInjectionUtils.InjectPools(system, World);
                EcsInjectionUtils.InjectQueries(system, World);
            }
        }
    }
}