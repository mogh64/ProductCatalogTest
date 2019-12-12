using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Filters
{
    public interface IProductFilter
    {
        IQueryable<Product> AddFilterToQuery(IQueryable<Product> query, ProductFilterInputDto filterInput);
    }
}
