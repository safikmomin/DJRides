﻿// <auto-generated />
using DjRidesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DjRidesApi.Migrations
{
    [DbContext(typeof(DjRidesContext))]
    [Migration("20171227211238_Added_UserID")]
    partial class Added_UserID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DjRidesApi.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street1")
                        .IsRequired();

                    b.Property<string>("Street2");

                    b.Property<int>("UserID");

                    b.Property<int>("ZipCode");

                    b.HasKey("AddressID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DjRidesApi.Models.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("LicenseNumber");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("UserID");

                    b.Property<string>("Year");

                    b.HasKey("CarID");

                    b.HasIndex("UserID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DjRidesApi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthID");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DjRidesApi.Models.Address", b =>
                {
                    b.HasOne("DjRidesApi.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("DjRidesApi.Models.Address", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DjRidesApi.Models.Car", b =>
                {
                    b.HasOne("DjRidesApi.Models.User", "User")
                        .WithMany("Car")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
