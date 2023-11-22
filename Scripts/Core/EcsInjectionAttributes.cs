using System;
using System.Collections.Generic;

namespace AleVerDes.LeoEcsLiteZoo
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAsAttribute : Attribute
    {
        private readonly Type[] _types;

        public IEnumerable<Type> Types => _types;

        public InjectAsAttribute(params Type[] types)
        {
            _types = types;
        }
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class IgnoreInjectionAttribute : Attribute
    {
    }
}