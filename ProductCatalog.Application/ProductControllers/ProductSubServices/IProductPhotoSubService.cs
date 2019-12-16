using ProductCatalog.Application.ProductControllers.Dtos;
using Sup.Framework.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductControllers.ProductSubServices
{
    public interface IProductPhotoSubService:ITransientDependency
    {
        Task AddPhoto(ProductPhotoInputDto photoInputDto);
        Task RemovePhoto(int productPhotoId);
        Task<ProductPhotoOutputDto> GetProductPhoto(int productId);
    }
}
