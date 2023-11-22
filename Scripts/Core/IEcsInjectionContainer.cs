using System.Collections.Generic;

namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsInjectionContainer
    {
        void AddInjector(IEcsInjector injector);
        IEnumerable<IEcsInjector> GetInjectors();
    }
}