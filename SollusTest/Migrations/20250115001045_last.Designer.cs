﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SollusTest.Data;

#nullable disable

namespace SollusTest.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20250115001045_last")]
    partial class last
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("SollusTest.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SollusTest.Models.Entities.Storage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("SollusTest.Models.Entities.Storage", b =>
                {
                    b.HasOne("SollusTest.Models.Entities.Product", null)
                        .WithOne("Storage")
                        .HasForeignKey("SollusTest.Models.Entities.Storage", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SollusTest.Models.Entities.Product", b =>
                {
                    b.Navigation("Storage");
                });
#pragma warning restore 612, 618
        }
    }
}
