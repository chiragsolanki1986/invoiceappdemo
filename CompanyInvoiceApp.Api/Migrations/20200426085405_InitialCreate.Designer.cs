﻿// <auto-generated />
using System;
using CompanyInvoiceApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyInvoiceApp.Api.Migrations
{
    [DbContext(typeof(CompanyInvoiceAppDbContext))]
    [Migration("20200426085405_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.Company", b =>
                {
                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ContactEmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyCode");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.CustomerDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCode");

                    b.HasIndex("InvoiceId")
                        .IsUnique();

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ShippingCharges")
                        .HasColumnType("float");

                    b.Property<double>("TaxRate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCode");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.InvoiceLineITem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Desccription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceLineITem");
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.ShippingDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId")
                        .IsUnique();

                    b.ToTable("ShippingDetails");
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.CustomerDetails", b =>
                {
                    b.HasOne("CompanyInvoiceApp.Api.Model.Company", null)
                        .WithMany("CustomerList")
                        .HasForeignKey("CompanyCode");

                    b.HasOne("CompanyInvoiceApp.Api.Model.Invoice", "Invoice")
                        .WithOne("CustomerDetails")
                        .HasForeignKey("CompanyInvoiceApp.Api.Model.CustomerDetails", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.Invoice", b =>
                {
                    b.HasOne("CompanyInvoiceApp.Api.Model.Company", "Company")
                        .WithMany("Invoices")
                        .HasForeignKey("CompanyCode");
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.InvoiceLineITem", b =>
                {
                    b.HasOne("CompanyInvoiceApp.Api.Model.Invoice", "Invoice")
                        .WithMany("LineItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyInvoiceApp.Api.Model.ShippingDetails", b =>
                {
                    b.HasOne("CompanyInvoiceApp.Api.Model.Invoice", "Invoice")
                        .WithOne("ShippingDetails")
                        .HasForeignKey("CompanyInvoiceApp.Api.Model.ShippingDetails", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
