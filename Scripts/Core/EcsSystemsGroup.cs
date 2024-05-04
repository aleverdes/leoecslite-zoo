using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public struct EcsSystemsGroup : IEcsSystems
    {
        private readonly IEcsSystems _updateSystems;
        private readonly IEcsSystems _lateUpdateSystems;
        private readonly IEcsSystems _fixedUpdateSystems;

        private readonly List<IEcsSystem> _allSystems;

        public EcsSystemsGroup(IEcsSystems updateSystems, IEcsSystems lateUpdateSystems, IEcsSystems fixedUpdateSystems)
        {
            _updateSystems = updateSystems;
            _lateUpdateSystems = lateUpdateSystems;
            _fixedUpdateSystems = fixedUpdateSystems;
            _allSystems = new List<IEcsSystem>();
            _allSystems.AddRange(_updateSystems.GetAllSystems());
            _allSystems.AddRange(_lateUpdateSystems.GetAllSystems());
            _allSystems.AddRange(_fixedUpdateSystems.GetAllSystems());
        }

        public IEcsSystems AddWorld(EcsWorld world, string name)
        {
            _updateSystems.AddWorld(world, name);
            _lateUpdateSystems.AddWorld(world, name);
            _fixedUpdateSystems.AddWorld(world, name);
            return this;
        }
        
        public T GetShared<T>() where T : class => _updateSystems.GetShared<T>();
        public EcsWorld GetWorld(string name = null) => _updateSystems.GetWorld(name);
        public Dictionary<string, EcsWorld> GetAllNamedWorlds() => _updateSystems.GetAllNamedWorlds();
        public IEcsSystems Add(IEcsSystem system) => throw new System.NotImplementedException();
        public List<IEcsSystem> GetAllSystems() => _allSystems;

        public void Init()
        {
            _updateSystems.Init();
            _lateUpdateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        public void Run()
        {
            _updateSystems.Run();
            _lateUpdateSystems.Run();
            _fixedUpdateSystems.Run();
        }

        public void Destroy()
        {
            _updateSystems.Destroy();
            _lateUpdateSystems.Destroy();
            _fixedUpdateSystems.Destroy();
        }
    }
}