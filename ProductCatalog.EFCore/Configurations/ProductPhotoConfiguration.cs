using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Core.Products;
using ProductCatalog.EFCore.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.EFCore.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.ToTable("ProductPhoto", Schema.Catalog);
            builder.HasIndex(p => new { p.PhotoId, p.ProductId }).IsUnique();
        }
    }
}
