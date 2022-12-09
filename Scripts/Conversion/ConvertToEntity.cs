using System.Collections;
using UnityEngine;

namespace AffenCode
{
    public sealed class ConvertToEntity : MonoBehaviour
    {
        [SerializeField] private ConvertTime _convertTime;
        [SerializeField] private ConvertMode _convertMode;
        [SerializeField] private CollectMode _collectMode;
        [SerializeField] private bool _destroyEntityWithGameObject;

        private int? _entity;
        private bool _converted;

        private IEnumerator Start()
        {
            if (_convertTime == ConvertTime.EndOfFrame)
            {
                yield return new WaitForEndOfFrame();
            }

            Convert();

            yield return true;
        }

        private void Convert()
        {
            if (_converted)
            {
                return;
            }

            _entity = EcsWorldProvider.DefaultWorldProvider.World.NewEntity();

            var components = GetComponents<IConvertToEntity>();
            foreach (var component in components)
            {
                component.ConvertToEntity(EcsWorldProvider.DefaultWorldProvider.World, _entity.Value);
            }

            if (_collectMode == CollectMode.IncludeChildren)
            {
                ConvertChildrenToEntity(transform);
            }

            if (_convertMode == ConvertMode.ConvertAndDestroy)
            {
                Destroy(gameObject);
            }

            _converted = true;
        }
        
        private void OnDestroy()
        {
            if (_converted && _destroyEntityWithGameObject && _entity.HasValue && EcsWorldProvider.DefaultWorldProvider && EcsWorldProvider.DefaultWorldProvider.World != null)
            {
                EcsWorldProvider.DefaultWorldProvider.World.DelEntity(_entity.Value);
                _entity = null;
            }
        }

        private void ConvertChildrenToEntity(Transform t)
        {
            for (var i = 0; i < t.childCount; ++i)
            {
                var child = t.GetChild(i);
                if (!child.TryGetComponent<ConvertToEntity>(out var convertToEntity))
                {
                    var components = child.GetComponents<IConvertToEntity>();
                    foreach (var component in components)
                    {
                        component.ConvertToEntity(EcsWorldProvider.DefaultWorldProvider.World, _entity.Value);
                    }
                    ConvertChildrenToEntity(child);
                }
            }
        }

        public int? GetEntity()
        {
            if (!_converted)
            {
                Convert();
            }
            return _entity;
        }
    }
}