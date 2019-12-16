﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductCatalog.EFCore;

namespace ProductCatalog.EFCore.Migrations
{
    [DbContext(typeof(ProductCatalogDbContext))]
    [Migration("20191214171849_change_schema")]
    partial class change_schema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductCatalog.Core.Products.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltAttribute");

                    b.Property<string>("MimeType");

                    b.Property<string>("TitleAttribute");

                    b.HasKey("Id");

                    b.ToTable("Photo","Catalog");
                });

            modelBuilder.Entity("ProductCatalog.Core.Products.PhotoBinary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BinaryData");

                    b.Property<int>("PhotoId");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("PhotoBinary","Catalog");
                });

            modelBuilder.Entity("ProductCatalog.Core.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Code");

                    b.Property<bool>("Confirmed");

                    b.Property<DateTime?>("LastUpdateTime");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("Product","Catalog");
                });

            modelBuilder.Entity("ProductCatalog.Core.Products.ProductPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("PhotoId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PhotoId", "ProductId")
                        .IsUnique();

                    b.ToTable("ProductPhoto","Catalog");
                });

            modelBuilder.Entity("ProductCatalog.Core.Products.PhotoBinary", b =>
                {
                    b.HasOne("ProductCatalog.Core.Products.Photo", "Photo")
                        .WithOne("PhotoBinary")
                        .HasForeignKey("ProductCatalog.Core.Products.PhotoBinary", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductCatalog.Core.Products.ProductPhoto", b =>
                {
                    b.HasOne("ProductCatalog.Core.Products.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductCatalog.Core.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
