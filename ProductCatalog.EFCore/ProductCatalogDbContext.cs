using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Products;
using Sup.Framework.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.EFCore
{
    public class ProductCatalogDbContext: CustomDbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCatalogDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
