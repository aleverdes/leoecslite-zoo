using System;
using System.Collections.Generic;

namespace AffenCode
{
    public class EcsFeatureInjections
    {
        private readonly EcsFeature _feature;
        private readonly List<EcsFeatureInjectionInfo> _injections = new List<EcsFeatureInjectionInfo>();

        public EcsFeatureInjections(EcsFeature feature)
        {
            _feature = feature;
        }

        public EcsFeatureInjections Register(object injectObject)
        {
            return Register(injectObject, injectObject.GetType());
        }

        public EcsFeatureInjections Register(object injectObject, params Type[] injectTypes)
        {
            _injections.Add(new EcsFeatureInjectionInfo
            {
                Types = injectTypes,
                Object = injectObject,
            });
            return this;
        }

        public EcsFeature GetFeature() => _feature;
        public IEnumerable<EcsFeatureInjectionInfo> GetInjections() => _injections;
    }

    public struct EcsFeatureInjectionInfo
    {
        public Type[] Types;
        public object Object;
    }
}