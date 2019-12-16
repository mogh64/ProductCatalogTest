
using AutoMapper;
using ProductCatalog.Application.ProductControllers.Dtos;
using ProductCatalog.Core.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.MapperConfigurations
{
    public class ProductAutoMapperProfile:Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<ProductInputDto, Product>();
            CreateMap<Product, ProductOutputDto>();
            //CreateMap<ProductPhotoInputDto, Photo>()
            //    .ForMember(a => a.PhotoBinary.BinaryData, x => x.MapFrom(p => p.BinaryData));
            //CreateMap<Photo, ProductPhotoOutputDto>()
            //    .ForMember(a => a.BinaryData, x => x.MapFrom(p => p.PhotoBinary.BinaryData));
        }
    }
}
