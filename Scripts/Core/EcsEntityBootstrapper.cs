using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    /// <summary>
    /// A class that makes it easy to convert an object to an entity.
    /// </summary>
    [RequireComponent(typeof(ConvertToEntity))]
    public abstract class EcsEntityBootstrapper : MonoBehaviour, IConvertableToEntity
    {
        protected EcsWorld World;
        protected int Entity;
        
        public virtual void ConvertToEntity(EcsWorld world, int entity)
        {
            World = world;
            Entity = entity;
            Setup();
        }

        protected ref T Add<T>() where T : struct
        {
            return ref World.GetPool<T>().Add(Entity);
        }
        
        protected ref T Get<T>() where T : struct
        {
            return ref World.GetPool<T>().Get(Entity);
        }
        
        protected ref T GetOrAdd<T>() where  T : struct
        {
            var pool = World.GetPool<T>();
            if (pool.Has(Entity))
                return ref pool.Get(Entity);
            return ref pool.Add(Entity);
        }

        protected bool Has<T>() where T : struct
        {
            return World.GetPool<T>().Has(Entity);
        }
        
        protected void Del<T>() where T : struct
        {
            World.GetPool<T>().Del(Entity);
        }

        protected abstract void Setup();
    }
}