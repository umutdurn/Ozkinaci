﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230901070014_guarantee")]
    partial class guarantee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Core.Models.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("CaseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("CylinderNumber")
                        .HasColumnType("int");

                    b.Property<string>("CylinderVolume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("EmptyWeight")
                        .HasColumnType("real");

                    b.Property<string>("EnginePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("ExpertizId")
                        .HasColumnType("int");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<string>("FuelConsumption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuelTank")
                        .HasColumnType("int");

                    b.Property<int>("Gear")
                        .HasColumnType("int");

                    b.Property<bool>("Guarantee")
                        .HasColumnType("bit");

                    b.Property<float>("Km")
                        .HasColumnType("real");

                    b.Property<string>("MaxSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Showcase")
                        .HasColumnType("bit");

                    b.Property<string>("To0100")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfTransfer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValveNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ColorId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ExpertizId");

                    b.ToTable("Advert");
                });

            modelBuilder.Entity("Core.Models.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("Core.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Core.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Core.Models.Expertiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArkaSagCamurluk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArkaSagKapi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArkaSolCamurluk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArkaSolKapi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArkaTampon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BagajKapagi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kaput")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnSagCamurluk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnSagKapi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnSolCamurluk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnSolKapi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnTampon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tavan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Expertiz");
                });

            modelBuilder.Entity("Core.Models.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvertId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertId");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("Core.Models.Advert", b =>
                {
                    b.HasOne("Core.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("Core.Models.Expertiz", "Expertiz")
                        .WithMany()
                        .HasForeignKey("ExpertizId");

                    b.Navigation("CarModel");

                    b.Navigation("Color");

                    b.Navigation("Equipment");

                    b.Navigation("Expertiz");
                });

            modelBuilder.Entity("Core.Models.CarModel", b =>
                {
                    b.HasOne("Core.Models.CarBrand", "CarBrand")
                        .WithMany("CarModel")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Category", "Category")
                        .WithMany("CarModels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Models.Equipment", b =>
                {
                    b.HasOne("Core.Models.CarModel", "CarModel")
                        .WithMany("Equipment")
                        .HasForeignKey("CarModelId");

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("Core.Models.Gallery", b =>
                {
                    b.HasOne("Core.Models.Advert", "Advert")
                        .WithMany("Gallery")
                        .HasForeignKey("AdvertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advert");
                });

            modelBuilder.Entity("Core.Models.Advert", b =>
                {
                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("Core.Models.CarBrand", b =>
                {
                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("Core.Models.CarModel", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Navigation("CarModels");
                });
#pragma warning restore 612, 618
        }
    }
}
