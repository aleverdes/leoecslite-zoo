using Leopotam.EcsLite;

namespace AleVerDes
{
    public interface IConvertToEntity
    {
        void ConvertToEntity(EcsWorld ecsWorld, int entity);
    }
}