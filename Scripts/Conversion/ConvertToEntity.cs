using System.Collections;
using UnityEngine;

namespace AffenCode
{
    public sealed class ConvertToEntity : MonoBehaviour
    {
        [SerializeField] private EcsWorldProvider _worldProvider;
        [SerializeField] private ConvertTime _convertTime;
        [SerializeField] private ConvertMode _convertMode;
        [SerializeField] private CollectMode _collectMode;
        [SerializeField] private bool _destroyEntityWithGameObject;

        private int? _entity;

        private void Reset()
        {
            _worldProvider = FindObjectOfType<EcsWorldProvider>();
        }
        
        private IEnumerator Start()
        {
            if (_convertTime == ConvertTime.EndOfFrame)
            {
                yield return new WaitForEndOfFrame();
            }
            
            if (!_worldProvider)
            {
                _worldProvider = EcsWorldProvider.DefaultWorldProvider;
            }
            
            _entity = _worldProvider.World.NewEntity();

            var components = GetComponents<IConvertToEntity>();
            foreach (var component in components)
            {
                component.ConvertToEntity(_worldProvider.World, _entity.Value);
            }

            if (_collectMode == CollectMode.IncludeChildren)
            {
                ConvertChildrenToEntity(transform);
            }

            if (_convertMode == ConvertMode.ConvertAndDestroy)
            {
                Destroy(gameObject);
            }

            yield return true;
        }
        
        private void OnDestroy()
        {
            if (_destroyEntityWithGameObject && _entity.HasValue)
            {
                _worldProvider.World.DelEntity(_entity.Value);
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
                        component.ConvertToEntity(_worldProvider.World, _entity.Value);
                    }
                    ConvertChildrenToEntity(child);
                }
            }
        }

        public int? GetEntity()
        {
            return _entity;
        }
    }
}