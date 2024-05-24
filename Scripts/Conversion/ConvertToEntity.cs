using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public sealed class ConvertToEntity : MonoBehaviour
    {
        [SerializeField] private ConvertMode _convertMode;
        [SerializeField] private CollectMode _collectMode;
        [SerializeField] private bool _destroyEntityWithGameObject;

        private bool _converted;
        private bool _hasAnyComponent;
        
        private EcsPackedEntityWithWorld _packedEntityWithWorld;

        public EcsPackedEntityWithWorld Convert(EcsWorld world)
        {
            if (_converted)
                return _packedEntityWithWorld;

            var entity = world.NewEntity();

            var components = GetComponents<IConvertableToEntity>();
            foreach (var component in components)
            {
                component.ConvertToEntity(world, entity);
                _hasAnyComponent = true;
            }

            if (_collectMode == CollectMode.IncludeChildren) 
                ConvertChildrenToEntity(transform, world, entity);

            if (!_hasAnyComponent)
            {
                Debug.LogError("Can't convert game object to entity without IConvertableToEntity components", this);
                return default;
            }

            if (_convertMode == ConvertMode.ConvertAndDestroy)
            {
                Destroy(gameObject);
            }

            _packedEntityWithWorld = world.PackEntityWithWorld(entity);
            _converted = true;
            return _packedEntityWithWorld;
        }
        
        private void OnDestroy()
        {
            if (_converted && _destroyEntityWithGameObject && _packedEntityWithWorld.Unpack(out var world, out var entity))
            {
                world.DelEntity(entity);
                _packedEntityWithWorld = default;
            }
        }

        private void ConvertChildrenToEntity(Transform t, EcsWorld world, int entity)
        {
            for (var i = 0; i < t.childCount; ++i)
            {
                var child = t.GetChild(i);

                if (child.TryGetComponent<IConvertableToEntity>(out _)) 
                    continue;
                
                var components = child.GetComponents<IConvertableToEntity>();
                foreach (var component in components)
                {
                    component.ConvertToEntity(world, entity);
                    _hasAnyComponent = true;
                }
                ConvertChildrenToEntity(child, world, entity);
            }
        }

        public EcsPackedEntityWithWorld GetEntity()
        {
            return _packedEntityWithWorld;
        }
    }
}
