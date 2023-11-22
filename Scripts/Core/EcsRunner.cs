using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    public class EcsRunner : MonoBehaviour, IEcsInjectionContainer
    {
        protected EcsWorld World;
        protected IEcsManager EcsManager;

        protected virtual void Awake()
        {
            World = new EcsWorld();
            ConvertToEntity.DefaultConversionWorld = World;
            
            EcsManager = new EcsManager();
            EcsManager.SetWorld(World);
        }
        
        public virtual void InstallModule(IEcsModuleInstaller moduleInstaller)
        {
            EcsManager.InstallModule(moduleInstaller);
        }

        public virtual void AddInjectionContext(EcsInjectionContext injectionContext)
        {
            injectionContext.InitInjector();
            EcsManager.AddInjector(injectionContext.GetInjector());
        }

        protected virtual void Update()
        {
            EcsManager.Update();
        }

        protected virtual void LateUpdate()
        {
            EcsManager.LateUpdate();
        }

        protected virtual void FixedUpdate()
        {
            EcsManager.FixedUpdate();
        }

        protected virtual void OnDestroy()
        {
            EcsManager.Destroy();
        }

        public virtual EcsWorld GetWorld()
        {
            return World;
        }

        public virtual IEcsManager GetManager()
        {
            return EcsManager;
        }

        public virtual void AddInjector(IEcsInjector injector)
        {
            EcsManager.AddInjector(injector);
        }

        public virtual IEnumerable<IEcsInjector> GetInjectors()
        {
            return EcsManager.GetInjectors();
        }
    }
}