using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;
using Sup.Framework.Dependency;
using Sup.Framework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Mapper
{
    public interface IProductMapperService:IMapperService<ProductInputDto,ProductOutputDto,Product>, ISingletonDependency
    {
    }
}
