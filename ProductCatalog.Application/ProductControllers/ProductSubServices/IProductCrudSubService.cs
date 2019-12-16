using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.ProductControllers.Dtos;
using Sup.Framework.Dependency;
using Sup.Framework.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductControllers.ProductSubServices
{
    public interface IProductCrudSubService:ITransientDependency
    {
        Task<ProductOutputDto> GetProduct(int id);
        Task<PagedResultDto<ProductOutputDto>> GetProducts(ProductFilterInputDto filterInput);
        Task EditProduct(ProductInputDto productInputDto);
        Task<ProductOutputDto> AddProduct(ProductInputDto productInputDto);
        Task RemoveProduct(int id);
    }
}
