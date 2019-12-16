using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Application.ProductControllers.Filters;
using ProductCatalog.Application.ProductControllers.Mapper;
using ProductCatalog.Core.Products.DomainService;
using Sup.Framework.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductControllers.ProductSubServices
{
    public class ProductCrudSubService: IProductCrudSubService
    {
        private readonly IProductMapperService productMapperService;
        private readonly IProductFilter productFilter;
        private readonly IProductDomainService productDomainService;
        public ProductCrudSubService(IProductMapperService productMapperService,
            IProductFilter productFilter,
            IProductDomainService productDomainService)
        {
            this.productMapperService = productMapperService;
            this.productFilter = productFilter;
            this.productDomainService = productDomainService;
        }
        public async Task<ProductOutputDto> AddProduct(ProductInputDto productInputDto)
        {
            var productEntity = productMapperService.MapToEntity(productInputDto);
            var output = await productDomainService.Add(productEntity);
            return productMapperService.MapToDto(output);
        }
      
        public Task EditProduct(ProductInputDto productInputDto)
        {
            var productEntity = productMapperService.MapToEntity(productInputDto);
            return productDomainService.Edit(productEntity);
        }               
       
        public async Task<ProductOutputDto> GetProduct(int id)
        {
           var entity = await this.productDomainService.Get(id);
            if (entity == null)
            {
                return null;
            }
           var productDto = productMapperService.MapToDto(entity);
           return productDto;
        }
       
        public async Task<PagedResultDto<ProductOutputDto>> GetProducts(ProductFilterInputDto filterInput)
        {
            List<ProductOutputDto> result = new List<ProductOutputDto>();
            var query = productDomainService.GetAll();
            query = productFilter.AddFilterToQuery(query, filterInput);
            var entityOutputs = await query.ToListAsync();
            entityOutputs.ForEach(x =>
            {
                result.Add(productMapperService.MapToDto(x));
            });
            return new PagedResultDto<ProductOutputDto>()
            {
                ResultList = result
            };
        }
      
        public Task RemoveProduct(int id)
        {
            return productDomainService.Delete(id);
        }
    }
}
