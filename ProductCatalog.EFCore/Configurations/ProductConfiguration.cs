using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Core.Products;
using ProductCatalog.EFCore.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.EFCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", Schema.Catalog);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
