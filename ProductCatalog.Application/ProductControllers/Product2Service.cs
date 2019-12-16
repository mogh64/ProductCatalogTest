using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.ProductControllers.Dtos;
using Sup.Framework.Services;
using Sup.Framework.Services.Dto;
using Sup.Framework.Tools.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductControllers
{
     [ApiVersion("2.0")]
     [Route("api/v{version:apiVersion}/Product")]
     [ApiController]
    public class Product2Service : IProductService
    {
        public Product2Service()
        {

        }
        [HttpPost("AddPhoto")]
        public Task AddPhoto(ProductPhotoInputDto photoInputDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ProductOutputDto> AddProduct(ProductInputDto productInputDto)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public Task EditProduct(ProductInputDto productInputDto)
        {
            throw new NotImplementedException();
        }
        [HttpPost("Export")]
        public Task<ExcelExportOutputDto> ExportExcel(ProductFilterInputDto filter)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public Task<ProductOutputDto> GetProduct(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetPhoto")]
        public Task<ProductPhotoOutputDto> GetProductPhoto(int productId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<PagedResultDto<ProductOutputDto>> GetProducts(ProductFilterInputDto filterInput)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("RemovePhoto")]
        public Task RemovePhoto(int productPhotoId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
