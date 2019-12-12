using Sup.Framework.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.TestService
{
    public interface ITest: ITransientDependency
    {
        string Get();
    }
}
