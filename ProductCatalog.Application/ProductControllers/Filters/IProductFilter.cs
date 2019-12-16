using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;
using Sup.Framework.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Filters
{
    public interface IProductFilter:ITransientDependency
    {
        IQueryable<Product> AddFilterToQuery(IQueryable<Product> query, ProductFilterInputDto filterInput);
    }
}
