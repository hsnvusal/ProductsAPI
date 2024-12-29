﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsAPI.Models;

#nullable disable

namespace ProductsAPI.Migrations
{
    [DbContext(typeof(ProductsContexts))]
    [Migration("20241228154107_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ProductsAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IsActive = true,
                            Price = 40000m,
                            ProductName = "Iphone 12"
                        },
                        new
                        {
                            ProductId = 2,
                            IsActive = true,
                            Price = 50000m,
                            ProductName = "Iphone 13"
                        },
                        new
                        {
                            ProductId = 3,
                            IsActive = false,
                            Price = 60000m,
                            ProductName = "Iphone 14"
                        },
                        new
                        {
                            ProductId = 4,
                            IsActive = true,
                            Price = 70000m,
                            ProductName = "Iphone 15"
                        },
                        new
                        {
                            ProductId = 5,
                            IsActive = true,
                            Price = 80000m,
                            ProductName = "Iphone 16"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
