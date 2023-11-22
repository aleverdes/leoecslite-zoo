using System;
using System.Collections;
using System.Linq;
using AleVerDes.LeoEcsLiteZoo;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace AleVerDes.LeoEcsLiteZoo
{
    public class SingleUnityObjectInjector<TContainer, TInjectable> : EcsInjectionContext 
        where TContainer : Object, IEcsInjectionContainer 
        where TInjectable : Object
    {
        [SerializeField] private TContainer _container;
        [SerializeField] private TInjectable _injectable;
        [SerializeField] private InjectionTime _injectionTime = InjectionTime.Start;
        private bool _isInjected;
        
        private void Awake()
        {
            if (_injectionTime == InjectionTime.Awake)
                Inject();
        }

        private IEnumerator Start()
        {
            if (_injectionTime == InjectionTime.Start)
            {
                Inject();
                yield break;
            }

            if (_injectionTime == InjectionTime.EndOfStartFrame)
            {
                yield return new WaitForEndOfFrame();
                Inject();
                yield break;
            }

            if (_injectionTime == InjectionTime.NextFrameAfterStart)
            {
                yield return null;
                Inject();
                yield break;
            }
        }

        private void OnEnable()
        {
            if (_injectionTime == InjectionTime.OnEnable)
                Inject();
        }

        public void Inject()
        {
            if (_isInjected) return;
            InitInjector();
            _container.AddInjector(GetInjector());
            _isInjected = true;
        }

        protected override void Reset()
        {
            _container = (TContainer) FindComponentInPrefabOrScene(typeof(TContainer));
            
            if (typeof(ScriptableObject).IsAssignableFrom(typeof(TInjectable)))
            {
#if UNITY_EDITOR
                var assetGuid = AssetDatabase.FindAssets("t:" + typeof(TInjectable).Name).FirstOrDefault();
                if (!string.IsNullOrEmpty(assetGuid))
                {
                    _injectable = AssetDatabase.LoadAssetAtPath<TInjectable>(AssetDatabase.GUIDToAssetPath(assetGuid));
                }
#endif
            }
            else if (typeof(Component).IsAssignableFrom(typeof(TInjectable)))
            {
                _injectable = (TInjectable) FindComponentInPrefabOrScene(typeof(TInjectable));
            }

            Object FindComponentInPrefabOrScene(Type componentType)
            {
#if UNITY_EDITOR
                if (PrefabStageUtility.GetCurrentPrefabStage() != null)
                    return PrefabStageUtility
                        .GetCurrentPrefabStage()
                        .FindComponentsOfType<Transform>()
                        .FirstOrDefault(x => x.GetComponent(componentType))?
                        .GetComponent(componentType);
#endif
                return FindObjectOfType(componentType);
            }
        }

        public override void InitInjector()
        {
            Injector.AddInjectionObject(_injectable);
        }

        private enum InjectionTime
        {
            Awake,
            Start,
            OnEnable,
            EndOfStartFrame,
            NextFrameAfterStart,
            Manual
        }
    }
}