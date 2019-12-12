using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Dtos
{
    public class ProductFilterInputDto
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
