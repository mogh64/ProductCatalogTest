using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;
using Sup.Framework.Base.Extensions;

namespace ProductCatalog.Application.ProductControllers.Filters
{
    public class ProductFilter : IProductFilter
    {
        public IQueryable<Product> AddFilterToQuery(IQueryable<Product> query, ProductFilterInputDto filterInput)
        {
            query = query.WhereIf(filterInput.Code.HasValue, p => p.Code == filterInput.Code);
            query = query.WhereIf(!string.IsNullOrWhiteSpace(filterInput.Name), p => p.Name.Contains(filterInput.Name));
            return query;
        }
    }
}
