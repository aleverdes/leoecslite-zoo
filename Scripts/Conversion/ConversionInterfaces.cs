using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IConvertableToEntity
    {
        void ConvertToEntity(EcsWorld world, int entity);
    }
}