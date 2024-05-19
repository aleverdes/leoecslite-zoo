using System;
using System.Collections;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace AleVerDes.LeoEcsLiteZoo
{
    public sealed class ConvertToEntity : MonoBehaviour
    {
        [Inject] private EcsWorld _world;
        
        [SerializeField] private ConvertTime _convertTime;
        [SerializeField] private ConvertMode _convertMode;
        [SerializeField] private CollectMode _collectMode;
        [SerializeField] private bool _destroyEntityWithGameObject;

        private int _entity;
        private bool _converted;
        private bool _hasAnyComponent;
        private EcsPackedEntityWithWorld _packedEntityWithWorld;

        private IEnumerator Start()
        {
            switch (_convertTime)
            {
                case ConvertTime.EndOfFrame:
                    yield return new WaitForEndOfFrame();
                    break;
                case ConvertTime.NextFrame:
                    yield return null;
                    break;
                case ConvertTime.Manual:
                    yield break;
            }

            Convert();

            yield return true;
        }

        public EcsPackedEntityWithWorld Convert()
        {
            Convert(_world);
            return _packedEntityWithWorld;
        }
        
        public void Convert(EcsWorld world)
        {
            if (_converted)
                return;

            _world = world;
            _entity = _world.NewEntity();

            var components = GetComponents<IConvertableToEntity>();
            foreach (var component in components)
            {
                component.ConvertToEntity(_world, _entity);
                _hasAnyComponent = true;
            }

            if (_collectMode == CollectMode.IncludeChildren) 
                ConvertChildrenToEntity(transform);

            if (!_hasAnyComponent)
            {
                Debug.LogError("Can't convert game object to entity without IConvertableToEntity components", this);
                return;
            }

            if (_convertMode == ConvertMode.ConvertAndDestroy)
            {
                Destroy(gameObject);
            }

            _packedEntityWithWorld = _world.PackEntityWithWorld(_entity);
            _converted = true;
        }
        
        private void OnDestroy()
        {
            if (_converted && _destroyEntityWithGameObject && _world != null)
            {
                _world.DelEntity(_entity);
                _entity = -1;
            }
        }

        private void ConvertChildrenToEntity(Transform t)
        {
            for (var i = 0; i < t.childCount; ++i)
            {
                var child = t.GetChild(i);

                if (child.TryGetComponent<IConvertableToEntity>(out _)) 
                    continue;
                
                var components = child.GetComponents<IConvertableToEntity>();
                foreach (var component in components)
                {
                    component.ConvertToEntity(_world, _entity);
                    _hasAnyComponent = true;
                }
                ConvertChildrenToEntity(child);
            }
        }

        public EcsPackedEntityWithWorld GetEntity()
        {
            if (!_converted)
                Convert();
            return _packedEntityWithWorld;
        }
    }
}
