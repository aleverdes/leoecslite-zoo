using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AffenCode
{
    public struct EcsSystemsGroup : IEcsSystems
    {
        public IEcsSystems UpdateSystems;
        public IEcsSystems LateUpdateSystems;
        public IEcsSystems FixedUpdateSystems;
        
        public T GetShared<T>() where T : class
        {
            return UpdateSystems.GetShared<T>();
        }

        public IEcsSystems AddWorld(EcsWorld world, string name)
        {
            UpdateSystems.AddWorld(world, name);
            LateUpdateSystems.AddWorld(world, name);
            FixedUpdateSystems.AddWorld(world, name);
            return this;
        }

        public EcsWorld GetWorld(string name = null)
        {
            return UpdateSystems.GetWorld(name);
        }

        public Dictionary<string, EcsWorld> GetAllNamedWorlds()
        {
            return UpdateSystems.GetAllNamedWorlds();
        }

        public IEcsSystems Add(IEcsSystem system)
        {
            throw new System.NotImplementedException();
        }

        public List<IEcsSystem> GetAllSystems()
        {
            var systems = new List<IEcsSystem>(UpdateSystems.GetAllSystems());
            systems.AddRange(LateUpdateSystems.GetAllSystems());
            systems.AddRange(FixedUpdateSystems.GetAllSystems());
            return systems;
        }

        public void Init()
        {
            UpdateSystems.Init();
            LateUpdateSystems.Init();
            FixedUpdateSystems.Init();
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            UpdateSystems.Destroy();
            LateUpdateSystems.Destroy();
            FixedUpdateSystems.Destroy();
        }
    }
}