using Sup.Framework.Domain.Auditing;
using Sup.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Core.Products
{
    public class Product : Entity, IHasLastUpdateTime
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? LastUpdateTime { get; set ; }
        public byte[] RowVersion { get; set; }
    }
}
