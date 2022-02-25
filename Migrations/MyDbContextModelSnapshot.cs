﻿// <auto-generated />
using System;
using Assignment11_EFCore_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntitySample.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment11_EFCore_2.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cosmetic"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fashion"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Technologies"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Funiture"
                        });
                });

            modelBuilder.Entity("Assignment11_EFCore_2.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Manufacturer = "Hai Ha",
                            Name = "Candy"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Manufacturer = "Yves",
                            Name = "Lipstick"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Manufacturer = "CocaCola",
                            Name = "Pepsi"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Manufacturer = "Pepsi",
                            Name = "Sting"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Manufacturer = "DG",
                            Name = "Jeans"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            Manufacturer = "Apple",
                            Name = "Iphone"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 6,
                            Manufacturer = "Hoa Phat",
                            Name = "Chair"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 6,
                            Manufacturer = "Hoa Phat",
                            Name = "Desk"
                        });
                });

            modelBuilder.Entity("Assignment11_EFCore_2.Data.Entities.Product", b =>
                {
                    b.HasOne("Assignment11_EFCore_2.Data.Entities.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Assignment11_EFCore_2.Data.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
