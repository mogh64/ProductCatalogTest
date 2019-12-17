using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Application.ProductControllers.Filters;
using ProductCatalog.Application.ProductControllers.Mapper;
using ProductCatalog.Core.Products;
using Sup.Framework.Tools.Excel;

namespace ProductCatalog.Application.ProductControllers.ProductSubServices
{
    public class ProductExportService: IProductExportService
    {
        private readonly IProductMapperService productMapperService;
        private readonly IProductRepository productRepository;
        private readonly IProductFilter productFilter;

        public ProductExportService(
            IProductMapperService productMapperService,
            IProductRepository productRepository,
            IProductFilter productFilter)
        {
            this.productMapperService = productMapperService;
            this.productRepository = productRepository;
            this.productFilter = productFilter;
        }

        public async Task<ExcelExportOutputDto> ExportExcel(ProductFilterInputDto filter)
        {
            List<ProductOutputDto> result = new List<ProductOutputDto>();
            var query = this.productRepository.GetAll();
            query = productFilter.AddFilterToQuery(query, filter);
            var entityOutputs = await query.ToListAsync();
            entityOutputs.ForEach(x =>
            {
                result.Add(productMapperService.MapToDto(x));
            });
            ProductExportListDto productExportListDto = new ProductExportListDto(result);
            ExcelExportBuilder excelExportBuilder = new ExcelExportBuilder();
           
             return await excelExportBuilder.CreateExcelExport(productExportListDto.GetExcelExportInputDto());
        }
    }
}
