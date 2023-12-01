using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public sealed class SingletonComponent<T> : IEcsCallback.IInit where T : struct
    {
        private EcsWorld _world;
        private EcsPool<T> _pool;
        private EcsQuery<T> _query;
        private int? _entity;

        public void Initialize()
        {
            CreateEntityIfDoesNotExists();
        }
        
        public ref T Get()
        {
            var entitiesCount = _query.GetFilter().GetEntitiesCount();
            if (entitiesCount > 1)
            {
                Debug.LogError($"Singleton component {typeof(T)} has more than one entity (Entities count: {entitiesCount})");
                foreach (var entity in _query)
                {
                    if (entitiesCount == 1) 
                        return ref _pool.Get(entity);
                    _pool.Del(entity);
                    entitiesCount--;
                }
            }
            return ref _pool.Get(CreateEntityIfDoesNotExists());
        }

        public int GetEntity() => CreateEntityIfDoesNotExists();
        
        private int CreateEntityIfDoesNotExists()
        {
            _entity ??= _world.NewEntity();
            if (!_pool.Has(_entity.Value))
                _pool.Add(_entity.Value);
            return _entity.Value;
        }
    }
}