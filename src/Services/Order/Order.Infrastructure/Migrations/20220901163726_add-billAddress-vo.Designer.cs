﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.Infrastructure.EntityFramework;

namespace Order.Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220901163726_add-billAddress-vo")]
    partial class addbillAddressvo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Order.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("CardName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Expiration")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Order", "dbo");
                });

            modelBuilder.Entity("Order.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("Order.Domain.ValueObjects.BillingAddress", "billingAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("AddressLine")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.Property<string>("Country")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.Property<string>("EmailAddress")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.Property<string>("FirstName")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.Property<string>("LastName")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.Property<string>("State")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(256)
                                .HasColumnType("varchar(256)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("billingAddress");
                });
#pragma warning restore 612, 618
        }
    }
}