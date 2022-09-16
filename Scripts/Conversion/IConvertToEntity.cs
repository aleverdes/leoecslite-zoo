using Leopotam.EcsLite;

namespace AffenCode
{
    public interface IConvertToEntity
    {
        void ConvertToEntity(EcsWorld ecsWorld, int entity);
    }
}