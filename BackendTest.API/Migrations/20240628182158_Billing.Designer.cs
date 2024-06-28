﻿// <auto-generated />
using System;
using BackendTest.API.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendTest.API.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20240628182158_Billing")]
    partial class Billing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BackendTest.API.Domain.Entities.Billing", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<string>("InvoiceAmount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("InvoiceDate")
                        .HasColumnType("bigint");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Billing");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.BillingLines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("BillingId")
                        .HasColumnType("int");

                    b.Property<string>("BillingId1")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillingId1");

                    b.HasIndex("ProductId");

                    b.ToTable("BillingLines");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BillingId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.Billing", b =>
                {
                    b.HasOne("BackendTest.API.Domain.Entities.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.BillingLines", b =>
                {
                    b.HasOne("BackendTest.API.Domain.Entities.Billing", "Billing")
                        .WithMany("BillingLines")
                        .HasForeignKey("BillingId1");

                    b.HasOne("BackendTest.API.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.Product", b =>
                {
                    b.HasOne("BackendTest.API.Domain.Entities.Billing", null)
                        .WithMany("Lines")
                        .HasForeignKey("BillingId");
                });

            modelBuilder.Entity("BackendTest.API.Domain.Entities.Billing", b =>
                {
                    b.Navigation("BillingLines");

                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
