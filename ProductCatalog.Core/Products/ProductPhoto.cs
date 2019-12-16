using Sup.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Core.Products
{
    public partial class ProductPhoto : Entity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets the picture
        /// </summary>
        public virtual Photo Photo { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
