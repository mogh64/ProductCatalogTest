using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Dependency
{
    public interface IIocManager:ISingletonDependency
    {
        IComponentContext IocContainer { get; set; }
    }
}
