using Sup.Framework.Dependency;
using Sup.Framework.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Core.Products
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
