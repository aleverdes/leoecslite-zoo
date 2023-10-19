using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IConvertToEntity
    {
        void ConvertToEntity(EcsWorld world, int entity);
    }
}