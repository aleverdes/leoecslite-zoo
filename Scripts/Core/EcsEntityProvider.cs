using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    /// <summary>
    /// A class that makes it easy to convert an object to an entity.
    /// </summary>
    [RequireComponent(typeof(ConvertToEntity))]
    public abstract class EcsEntityProvider : MonoBehaviour, IConvertableToEntity
    {
        protected EcsWorld World;
        protected int EntityId;
        
        public virtual void ConvertToEntity(EcsWorld world, int entity)
        {
            World = world;
            EntityId = entity;
            Setup();
        }

        protected ref T Add<T>() where T : struct
        {
            return ref World.GetPool<T>().Add(EntityId);
        }
        
        protected ref T Get<T>() where T : struct
        {
            return ref World.GetPool<T>().Get(EntityId);
        }
        
        protected ref T GetOrAdd<T>() where  T : struct
        {
            var pool = World.GetPool<T>();
            if (pool.Has(EntityId))
                return ref pool.Get(EntityId);
            return ref pool.Add(EntityId);
        }

        protected bool Has<T>() where T : struct
        {
            return World.GetPool<T>().Has(EntityId);
        }
        
        protected void Del<T>() where T : struct
        {
            World.GetPool<T>().Del(EntityId);
        }

        protected abstract void Setup();
    }
}