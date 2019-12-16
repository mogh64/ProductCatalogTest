using Sup.Framework.Dependency;
using Sup.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Products.DomainService
{
    public interface IProductDomainService: IDomainService<Product>, ISingletonDependency
    {
        

    }
}
