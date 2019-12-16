using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;

namespace ProductCatalog.Application.ProductControllers.Mapper
{
    public class ProductMapperService : IProductMapperService
    {
        private readonly IMapper mapper;

        public ProductMapperService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public ProductOutputDto MapToDto(Product entity)
        {
           return  mapper.Map<ProductOutputDto>(entity);
        }

        public Product MapToEntity(ProductInputDto input)
        {
            return mapper.Map<Product>(input);
        }
    }
}
