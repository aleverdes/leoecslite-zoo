using Leopotam.EcsLite;

namespace AffenCode
{
    public interface IEcsSystemsContext
    {
        EcsManager Manager { get; }
        EcsWorld World { get; }
        UnityEcsSystems Systems { get; }
        
        EcsSystemsContext Add(EcsFeature feature);
    }
    
    public sealed class EcsSystemsContext
    {
        public EcsManager Manager { get; }
        public EcsWorld World { get; }
        public UnityEcsSystems Systems { get; }

        public EcsSystemsContext(EcsManager ecsManager, EcsWorld ecsWorld)
        {
            Manager = ecsManager;
            World = ecsWorld;
            Systems = new UnityEcsSystems
            {
                UpdateSystems = new EcsSystems(World),
                LateUpdateSystems = new EcsSystems(World),
                FixedUpdateSystems = new EcsSystems(World)
            };
        }

        public EcsSystemsContext Add(IEcsFeature feature)
        {
            feature.Setup();
            
            foreach (var system in feature.GetUpdateSystems().GetSystems())
            {
                EcsInjector.Inject(system, this, typeof(IEcsSystemsContext));
                EcsInjector.Inject(system, this, typeof(EcsSystemsContext));
                Systems.UpdateSystems.Add(system);
            }
            
            foreach (var system in feature.GetLateUpdateSystems().GetSystems())
            {
                EcsInjector.Inject(system, this, typeof(IEcsSystemsContext));
                EcsInjector.Inject(system, this, typeof(EcsSystemsContext));
                Systems.LateUpdateSystems.Add(system);
            }
            
            foreach (var system in feature.GetFixedUpdateSystems().GetSystems())
            {
                EcsInjector.Inject(system, this, typeof(IEcsSystemsContext));
                EcsInjector.Inject(system, this, typeof(EcsSystemsContext));
                Systems.FixedUpdateSystems.Add(system);
            }

            return this;
        }
    }
}