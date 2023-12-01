using System.Collections.Generic;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsManager
    {
        void SetWorld(EcsWorld ecsWorld);

        void Update();
        void LateUpdate();
        void FixedUpdate();

        void Destroy();

        IEcsModuleContainer InstallModule(IEcsModuleInstaller moduleInstaller);
        void UninstallModule(IEcsModuleContainer moduleContainer);
        
        void AddInjector(IEcsInjector injector);
        IEnumerable<IEcsInjector> GetInjectors();
    }
    
    public class EcsManager : IEcsManager, IEcsInjectionContainer
    {
        protected readonly HashSet<IEcsModuleContainer> Modules = new();
        protected readonly HashSet<IEcsInjector> Injectors = new();

        protected EcsWorld World;
        
        private readonly HashSet<IEcsCallback.IInit> _initCallbacks = new();
        private readonly HashSet<IEcsCallback.IInit> _processedInitCallbacks = new();
        
        private readonly HashSet<IEcsCallback.IUpdate> _updateCallbacks = new();
        private readonly HashSet<IEcsCallback.IFixedUpdate> _fixedUpdateCallbacks = new();
        private readonly HashSet<IEcsCallback.ILateUpdate> _lateUpdateCallbacks = new();

        public virtual void SetWorld(EcsWorld ecsWorld)
        {
            World = ecsWorld;
        }

        public virtual void Update()
        {
            foreach (var systemsContext in Modules)
                if (systemsContext.Enabled)
                    systemsContext.GetSystemsGroup().UpdateSystems.Run();

            foreach (var update in _updateCallbacks)
                update.Update();
        }

        public virtual void LateUpdate()
        {
            foreach (var systemsContext in Modules)
                if (systemsContext.Enabled)
                    systemsContext.GetSystemsGroup().LateUpdateSystems.Run();
            
            foreach (var lateUpdate in _lateUpdateCallbacks)
                lateUpdate.LateUpdate();
        }

        public virtual void FixedUpdate()
        {
            foreach (var systemsContext in Modules)
                if (systemsContext.Enabled)
                    systemsContext.GetSystemsGroup().FixedUpdateSystems.Run();
            
            foreach (var fixedUpdate in _fixedUpdateCallbacks)
                fixedUpdate.FixedUpdate();
        }

        public virtual void Destroy()
        {
            foreach (var systemsContext in Modules) 
                systemsContext.GetSystemsGroup().Destroy();
        }
        
        public virtual IEcsModuleContainer InstallModule(IEcsModuleInstaller moduleInstaller)
        {
            var module = moduleInstaller.Install();
            module.Initialize(World);
            Modules.Add(module);
            AddInjector(module.GetInjector());
            module.OnInstall();
            foreach (var initialize in _initCallbacks)
                if (_processedInitCallbacks.Add(initialize))
                    initialize.Initialize();
            module.GetSystemsGroup().Init();
            return module;
        }

        public virtual void UninstallModule(IEcsModuleContainer moduleContainer)
        {
            moduleContainer.OnUninstall();
            Modules.Remove(moduleContainer);
        }
        
        public virtual void AddInjector(IEcsInjector injector)
        {
            Injectors.Add(injector);
            RebuildInjections();

            foreach (var injectionObject in injector.GetInjectionObjects().Values)
            {
                if (injectionObject is IEcsCallback.IInit initialize)
                    _initCallbacks.Add(initialize);
                
                if (injectionObject is IEcsCallback.IUpdate update)
                    _updateCallbacks.Add(update);
                
                if (injectionObject is IEcsCallback.IFixedUpdate fixedUpdate)
                    _fixedUpdateCallbacks.Add(fixedUpdate);
                
                if (injectionObject is IEcsCallback.ILateUpdate lateUpdate)
                    _lateUpdateCallbacks.Add(lateUpdate);
            }
        }
        
        public virtual IEnumerable<IEcsInjector> GetInjectors()
        {
            return Injectors;
        }

        protected virtual void RebuildInjections()
        {
            foreach (var module in Modules)
            {
                foreach (var system in module.GetAllSystems()) 
                    Inject(system);

                foreach (var injector in Injectors)
                foreach (var injectionObject in injector.GetInjectionObjects().Values)
                    Inject(injectionObject);

                void Inject(object target)
                {
                    EcsInjectionUtils.Inject(target, World, typeof(EcsWorld));
                    foreach (var injector in Injectors) 
                        injector.ExecuteInjection(target);
                    EcsInjectionUtils.InjectPools(target, World);
                    EcsInjectionUtils.InjectQueries(target, World);
                    module.GetInjector().ExecuteInjection(target);
                }
            }
        }
    }
}