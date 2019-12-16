using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Core.Products;
using ProductCatalog.EFCore.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.EFCore.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photo", Schema.Catalog);
        }
    }
    public class PhotoBinaryConfiguration : IEntityTypeConfiguration<PhotoBinary>
    {
        public void Configure(EntityTypeBuilder<PhotoBinary> builder)
        {
            builder.ToTable("PhotoBinary", Schema.Catalog);
        }
    }
}
