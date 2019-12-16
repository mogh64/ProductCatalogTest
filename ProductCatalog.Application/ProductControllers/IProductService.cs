using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Application.ProductControllers.ProductSubServices;
using Sup.Framework.Services;
using Sup.Framework.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductControllers
{
    public interface IProductService: IProductExportService, IProductPhotoSubService, IProductCrudSubService
    {
        

    }
}
