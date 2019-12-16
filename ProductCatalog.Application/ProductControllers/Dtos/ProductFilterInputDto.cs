using Sup.Framework.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Dtos
{
    public class ProductFilterInputDto: PagedAndSortedResultRequestDto
    {
        public long? Code { get; set; }
        public string Name { get; set; }
       
    }
}
