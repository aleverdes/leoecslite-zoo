using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsModuleInstaller
    {
        public IEcsModuleContainer Install();
    }
    
    public class EcsModuleInstaller<T> : MonoBehaviour, IEcsModuleInstaller where T : IEcsModule, new()
    {
        [SerializeField] protected EcsRunner EcsRunner;
        [SerializeField] protected EcsInjectionContext[] EcsInjectionContexts;

        private void Reset()
        {
#if UNITY_EDITOR
            if (PrefabStageUtility.GetCurrentPrefabStage() == null)
                EcsRunner = FindObjectOfType<EcsRunner>();
            else
                EcsRunner = (EcsRunner)PrefabStageUtility
                    .GetCurrentPrefabStage()
                    .FindComponentsOfType<Transform>()
                    .Where(x => x.GetComponent(typeof(EcsRunner)))
                    .Select(x => x.GetComponent(typeof(EcsRunner)))
                    .FirstOrDefault();

            if (PrefabStageUtility.GetCurrentPrefabStage() == null)
                EcsInjectionContexts = FindObjectsOfType<EcsInjectionContext>();
            else
                EcsInjectionContexts = (EcsInjectionContext[])PrefabStageUtility
                    .GetCurrentPrefabStage()
                    .FindComponentsOfType<Transform>()
                    .Where(x => x.GetComponent(typeof(EcsInjectionContext)))
                    .Select(x => x.GetComponent(typeof(EcsInjectionContext)));
#endif
        }

        private void Start()
        {
            EcsRunner.InstallModule(this);
            foreach (var ecsInjectionContext in EcsInjectionContexts) 
                EcsRunner.AddInjectionContext(ecsInjectionContext);
        }

        public IEcsModuleContainer Install()
        {
            var moduleContainer = new EcsModuleContainer();
            var module = new T();
            moduleContainer.AddFeatures(module.AddFeatures(new EcsFeatures()));
            return moduleContainer;
        }
    }
}