﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Noon.Infrastructure;

#nullable disable

namespace Noon.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231224153621_ProductUpdate")]
    partial class ProductUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Noon.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.BrandCategory", b =>
                {
                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BrandId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BrandCategory");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Money", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Moneys");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SpecifiedCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SpecifiedCategoryId");

                    b.HasIndex("WishListId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.SpecifiedCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SpecifiedCategories");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Return", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReturnUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ReturnUserId");

                    b.ToTable("Return");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Tokens.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Noon.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasDefaultValue("User");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Noon.Domain.Entities.WishList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WishListUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WishListUserId")
                        .IsUnique();

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Address", b =>
                {
                    b.HasOne("Noon.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("AddressUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noon.Domain.Entities.User", null)
                        .WithMany("Address")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Order", b =>
                {
                    b.HasOne("Noon.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("OrderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.BrandCategory", b =>
                {
                    b.HasOne("Noon.Domain.Entities.Products.Brand", "Brand")
                        .WithMany("BrandCategories")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noon.Domain.Entities.Products.Category", "Category")
                        .WithMany("BrandCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Money", b =>
                {
                    b.HasOne("Noon.Domain.Entities.Products.Product", "Product")
                        .WithOne("Price")
                        .HasForeignKey("Noon.Domain.Entities.Products.Money", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("Noon.Domain.Entities.Products.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noon.Domain.Entities.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noon.Domain.Entities.Products.SpecifiedCategory", "SpecifiedCategory")
                        .WithMany("Products")
                        .HasForeignKey("SpecifiedCategoryId");

                    b.HasOne("Noon.Domain.Entities.WishList", null)
                        .WithMany("Products")
                        .HasForeignKey("WishListId");

                    b.Navigation("Brand");

                    b.Navigation("Order");

                    b.Navigation("SpecifiedCategory");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.SpecifiedCategory", b =>
                {
                    b.HasOne("Noon.Domain.Entities.Products.Category", "Category")
                        .WithMany("SpecifiedCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Return", b =>
                {
                    b.HasOne("Noon.Domain.Entities.User", "User")
                        .WithMany("Returns")
                        .HasForeignKey("ReturnUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Tokens.RefreshToken", b =>
                {
                    b.HasOne("Noon.Domain.Entities.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Noon.Domain.Entities.Tokens.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Noon.Domain.Entities.WishList", b =>
                {
                    b.HasOne("Noon.Domain.Entities.User", "User")
                        .WithOne("WishList")
                        .HasForeignKey("Noon.Domain.Entities.WishList", "WishListUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Brand", b =>
                {
                    b.Navigation("BrandCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Category", b =>
                {
                    b.Navigation("BrandCategories");

                    b.Navigation("SpecifiedCategories");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("Price");
                });

            modelBuilder.Entity("Noon.Domain.Entities.Products.SpecifiedCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Noon.Domain.Entities.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Orders");

                    b.Navigation("RefreshToken")
                        .IsRequired();

                    b.Navigation("Returns");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("Noon.Domain.Entities.WishList", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
