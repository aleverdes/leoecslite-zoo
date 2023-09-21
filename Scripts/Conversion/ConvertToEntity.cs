using System;
using System.Collections;
using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public sealed class ConvertToEntity : MonoBehaviour
    {
        public static EcsWorld DefaultConversionWorld { get; set; }
        
        [SerializeField] private ConvertTime _convertTime;
        [SerializeField] private ConvertMode _convertMode;
        [SerializeField] private CollectMode _collectMode;
        [SerializeField] private bool _destroyEntityWithGameObject;

        private EcsWorld _world;
        private int? _entity;
        private bool _converted;
        private bool _hasAnyComponent;

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

        public void Convert()
        {
            Convert(GetConversionWorld());
        }
        
        public void Convert(EcsWorld world)
        {
            if (_converted)
            {
                return;
            }

            _world = world;
            _entity = _world.NewEntity();

            var components = GetComponents<IConvertToEntity>();
            
            foreach (var component in components)
            {
                component.ConvertToEntity(_world, _entity.Value);
                _hasAnyComponent = true;
            }

            if (_collectMode == CollectMode.IncludeChildren)
            {
                ConvertChildrenToEntity(transform);
            }

            if (!_hasAnyComponent)
            {
                Debug.LogError("Can't convert game object to entity without IConvertToEntity components", this);
                return;
            }

            if (_convertMode == ConvertMode.ConvertAndDestroy)
            {
                Destroy(gameObject);
            }

            _converted = true;
        }
        
        private void OnDestroy()
        {
            if (_converted && _destroyEntityWithGameObject && _entity.HasValue && _world != null)
            {
                _world.DelEntity(_entity.Value);
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
                        component.ConvertToEntity(DefaultConversionWorld, _entity.Value);
                        _hasAnyComponent = true;
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

        private static EcsWorld GetConversionWorld()
        {
            if (DefaultConversionWorld != null)
            {
                return DefaultConversionWorld;
            }

            throw new Exception("World for conversion not found. Use ConvertToEntity.DefaultConversionWorld for set it.");
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetStatic()
        {
            DefaultConversionWorld = null;
        }
    }
}