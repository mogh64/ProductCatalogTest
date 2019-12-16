using Sup.Framework.Domain.Entities;
using Sup.Framework.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Dtos
{
    public class ProductInputDto : EntityDto
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }                
        public bool Confirmed { get; set; } = false;
        public byte[] RowVersion { get; set; }
    }
}
