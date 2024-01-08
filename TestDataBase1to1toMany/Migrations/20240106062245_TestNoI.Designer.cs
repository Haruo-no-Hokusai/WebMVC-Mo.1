﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDataBase1to1toMany.Data;

#nullable disable

namespace TestDataBase1to1toMany.Migrations
{
    [DbContext(typeof(FileManagementcs))]
    [Migration("20240106062245_TestNoI")]
    partial class TestNoI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("Components");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.ComponentToProduct", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "ComponentId");

                    b.HasIndex("ComponentId");

                    b.ToTable("ComponentToProduct");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Component", b =>
                {
                    b.HasOne("TestDataBase1to1toMany.Models.Feature", "Feature")
                        .WithOne("Component")
                        .HasForeignKey("TestDataBase1to1toMany.Models.Component", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TestDataBase1to1toMany.Models.ProductExtend", "ProductExtend", b1 =>
                        {
                            b1.Property<int>("ComponentId")
                                .HasColumnType("int");

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Weight")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ComponentId");

                            b1.ToTable("Components");

                            b1.WithOwner()
                                .HasForeignKey("ComponentId");
                        });

                    b.Navigation("Feature");

                    b.Navigation("ProductExtend")
                        .IsRequired();
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.ComponentToProduct", b =>
                {
                    b.HasOne("TestDataBase1to1toMany.Models.Component", "Component")
                        .WithMany()
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestDataBase1to1toMany.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.ProductDetail", b =>
                {
                    b.HasOne("TestDataBase1to1toMany.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Products", b =>
                {
                    b.HasOne("TestDataBase1to1toMany.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TestDataBase1to1toMany.Models.ProductExtend", "ProductExtend", b1 =>
                        {
                            b1.Property<int>("ProductsId")
                                .HasColumnType("int");

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Weight")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductsId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductsId");
                        });

                    b.Navigation("Category");

                    b.Navigation("ProductExtend")
                        .IsRequired();
                });

            modelBuilder.Entity("TestDataBase1to1toMany.Models.Feature", b =>
                {
                    b.Navigation("Component")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
