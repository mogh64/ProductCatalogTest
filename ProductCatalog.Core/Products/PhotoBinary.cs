using Sup.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Core.Products
{
    public class PhotoBinary:Entity
    {
        public byte[] BinaryData { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the picture
        /// </summary>
        public virtual Photo Photo { get; set; }
    }
}
