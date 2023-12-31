﻿// <auto-generated />
using System;
using EMS_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMS_App.Migrations
{
    [DbContext(typeof(EMSContext))]
    [Migration("20231208234012_v9-combiningContext")]
    partial class v9combiningContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EMS_App.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("EMS_App.Models.Billing", b =>
                {
                    b.Property<int>("BillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingId"));

                    b.Property<string>("BAddress1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BillingId");

                    b.ToTable("Billing");
                });

            modelBuilder.Entity("EMS_App.Models.Event", b =>
                {
                    b.Property<string>("Ename")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EBanner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ediscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ename");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("EMS_App.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiryDateYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("EMS_App.Models.Program", b =>
                {
                    b.Property<Guid>("eventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("eventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eventEndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("eventStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("eventID");

                    b.ToTable("events");
                });

            modelBuilder.Entity("EMS_App.Models.Purchase", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BillingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Uemail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("EMS_App.Models.Speaker", b =>
                {
                    b.Property<int>("Sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sid"));

                    b.Property<string>("SBio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Simage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sid");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("EMS_App.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("EMS_App.Models.TicketPurchase", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "TicketId");

                    b.ToTable("TicketPurchase");
                });
#pragma warning restore 612, 618
        }
    }
}
