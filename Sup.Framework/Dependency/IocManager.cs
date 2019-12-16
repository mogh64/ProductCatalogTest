using Autofac;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sup.Framework.Dependency
{
    public class IocManager : IIocManager
    {
        public IocManager(IComponentContext container)
        {
            IocContainer = container;
        }
        public IComponentContext IocContainer { get ; set ; }
    }
}
