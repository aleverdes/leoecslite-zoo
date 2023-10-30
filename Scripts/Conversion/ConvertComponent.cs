using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public abstract class ConvertComponent<T> : MonoBehaviour, IConvertToEntity where T : struct
    {
        public T Value;
        
        public void ConvertToEntity(EcsWorld world, int entity)
        {
            var pool = world.GetPool<T>();
            pool.Add(entity) = Value;
        }
    }
}