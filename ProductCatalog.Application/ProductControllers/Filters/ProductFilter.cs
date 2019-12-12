using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;

namespace ProductCatalog.Application.ProductControllers.Filters
{
    public class ProductFilter : IProductFilter
    {
        public IQueryable<Product> AddFilterToQuery(IQueryable<Product> query, ProductFilterInputDto filterInput)
        {
            throw new NotImplementedException();
        }
    }
}
