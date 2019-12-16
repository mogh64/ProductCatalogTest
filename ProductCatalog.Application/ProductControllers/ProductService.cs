using Autofac;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Application.ProductControllers.Filters;
using ProductCatalog.Application.ProductControllers.Mapper;
using ProductCatalog.Application.ProductControllers.ProductSubServices;
using ProductCatalog.Application.TestService;
using ProductCatalog.Core.Products.DomainService;
using Sup.Framework.Dependency;
using Sup.Framework.Services;
using Sup.Framework.Services.Dto;
using Sup.Framework.Tools.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Product")]
    [ApiController]
    public class ProductController: SupController, IProductService
    {
        private readonly IIocManager iocManager;
        private readonly IProductCrudSubService productCrudSubService;

        public ProductController(IIocManager iocManager,
            IProductCrudSubService productCrudSubService
            )
        {
            this.iocManager = iocManager;
            this.productCrudSubService = productCrudSubService;
        }
        [HttpPost("AddPhoto")]
        public Task AddPhoto(ProductPhotoInputDto photoInputDto)
        {
            var productPhotoSubService = this.iocManager.IocContainer.Resolve<IProductPhotoSubService>();
            return productPhotoSubService.AddPhoto(photoInputDto);
        }

        [HttpPost]
        public  Task<ProductOutputDto> AddProduct(ProductInputDto productInputDto)
        {            
            return productCrudSubService.AddProduct(productInputDto);
        }
        [HttpPut]
        public Task EditProduct(ProductInputDto productInputDto)
        {
            return productCrudSubService.EditProduct(productInputDto);
        }
        [HttpPost("Export")]
        public Task<ExcelExportOutputDto> ExportExcel(ProductFilterInputDto filterInput)
        {
            var productExportService = this.iocManager.IocContainer.Resolve<IProductExportService>();
            return productExportService.ExportExcel(filterInput);
        }
        [HttpGet("{id}")]
        public Task<ProductOutputDto> GetProduct(int id)
        {
            return productCrudSubService.GetProduct(id);
        }
        [HttpGet("GetPhoto")]
        public Task<ProductPhotoOutputDto> GetProductPhoto(int productId)
        {
            var productPhotoSubService = this.iocManager.IocContainer.Resolve<IProductPhotoSubService>();
            return productPhotoSubService.GetProductPhoto(productId);
        }

        [HttpGet]
        public Task<PagedResultDto<ProductOutputDto>> GetProducts([FromQuery]ProductFilterInputDto filterInput)
        {
            return productCrudSubService.GetProducts(filterInput);
        }
        [HttpDelete("RemovePhoto")]
        public Task RemovePhoto(int productPhotoId)
        {
            var productPhotoSubService = this.iocManager.IocContainer.Resolve<IProductPhotoSubService>();
            return productPhotoSubService.RemovePhoto(productPhotoId);
        }

        [HttpDelete]
        public Task RemoveProduct(int id)
        {
            return productCrudSubService.RemoveProduct(id);
        }
    }
}
