using System;
using System.Collections.Generic;

namespace AffenCode
{
    public interface IEcsInjector
    {
        IEcsInjector AddInjectionObject(object injectionObject);
        IEcsInjector AddInjectionObject<T>(object injectionObject);
        IEcsInjector AddInjectionObject(object injectionObject, Type type);
        IEcsInjector AddInjectionObject(object injectionObject, params Type[] type);

        IEcsInjector RemoveInjectionObject(Type injectionType);
        IEcsInjector RemoveInjectionObject<T>();
        IEcsInjector RemoveInjectionObject(object injectionObjectToRemove);

        Dictionary<Type, object> GetInjectionObjects();

        void ExecuteInjection(object target);
    }
    
    public sealed class EcsInjector : IEcsInjector
    {
        private readonly Dictionary<Type, object> _injectionObjects = new();

        public IEcsInjector AddInjectionObject(object injectionObject)
        {
            _injectionObjects.Add(injectionObject.GetType(), injectionObject);
            return this;
        }
        
        public IEcsInjector AddInjectionObject<T>(object injectionObject)
        {
            _injectionObjects.Add(typeof(T), injectionObject);
            return this;
        }
        
        public IEcsInjector AddInjectionObject(object injectionObject, Type type)
        {
            if (!type.IsInstanceOfType(injectionObject))
            {
                throw new Exception($"Can't add object {injectionObject} to injection-list because object's type {injectionObject.GetType()} isn't assignable from {type}");
            }
            
            _injectionObjects.Add(type, injectionObject);
            return this;
        }

        public IEcsInjector AddInjectionObject(object injectionObject, Type[] types)
        {
            foreach (var type in types)
            {
                AddInjectionObject(injectionObject, type);
            }
            return this;
        }

        public IEcsInjector RemoveInjectionObject(Type injectionType)
        {
            _injectionObjects.Remove(injectionType);
            return this;
        }

        public IEcsInjector RemoveInjectionObject<T>()
        {
            _injectionObjects.Remove(typeof(T));
            return this;
        }

        public IEcsInjector RemoveInjectionObject(object injectionObjectToRemove)
        {
            var toRemove = new HashSet<Type>();
            
            foreach (var (injectionType, injectionObject) in _injectionObjects)
            {
                if (injectionObjectToRemove == injectionObject)
                {
                    toRemove.Add(injectionType);
                }
            }

            foreach (var injectionType in toRemove)
            {
                _injectionObjects.Remove(injectionType);
            }
            
            return this;
        }

        public Dictionary<Type, object> GetInjectionObjects()
        {
            return _injectionObjects;
        }

        public void ExecuteInjection(object target)
        {
            foreach (var (injectionType, injectionObject) in _injectionObjects)
            {
                EcsInjection.Inject(target, injectionObject, injectionType);
            }
        }
    }
}