using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Application.ProductControllers.Dtos;

namespace ProductCatalog.Application.ProductControllers.ProductSubServices
{
    public class ProductPhotoSubService : IProductPhotoSubService
    {
        public ProductPhotoSubService()
        {

        }

        public Task AddPhoto(ProductPhotoInputDto photoInputDto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductPhotoOutputDto> GetProductPhoto(int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemovePhoto(int productPhotoId)
        {
            throw new NotImplementedException();
        }
    }
}
