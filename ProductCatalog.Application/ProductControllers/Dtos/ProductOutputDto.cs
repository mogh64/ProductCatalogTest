using Sup.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers.Dtos
{
    public class ProductOutputDto: EntityDto
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
