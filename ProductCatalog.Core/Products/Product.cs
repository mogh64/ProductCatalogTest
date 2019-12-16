using Sup.Framework.Domain.Auditing;
using Sup.Framework.Domain.Entities;
using Sup.Framework.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Core.Products
{
    public class Product : Entity, IHasLastUpdateTime, IObjectValidator
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }       
        public bool Confirmed { get; set; } = false;
        public DateTime? LastUpdateTime { get; set ; }
        public byte[] RowVersion { get; set; }

        public bool IsValid()
        {
            if (Price <= 0)
                return false;
            if (Price > 999)
            {
                if (!Confirmed)
                {
                    return false;
                }
            }                
            return true;
        }
    }
}
