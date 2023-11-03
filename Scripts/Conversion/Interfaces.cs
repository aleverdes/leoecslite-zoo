using System;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    [Obsolete("Use IConvertableToEntity instead; will be removed in next major version")]
    public interface IConvertToEntity
    {
        void ConvertToEntity(EcsWorld world, int entity);
    }
    
    public interface IConvertableToEntity
    {
        void ConvertToEntity(EcsWorld world, int entity);
    }
}