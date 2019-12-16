using ProductCatalog.Application.ProductControllers.Dtos;
using Sup.Framework.Dependency;
using Sup.Framework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.ProductSubServices
{
    public interface IProductExportService: IExcelExport<ProductFilterInputDto>, ITransientDependency
    {
    }
}
