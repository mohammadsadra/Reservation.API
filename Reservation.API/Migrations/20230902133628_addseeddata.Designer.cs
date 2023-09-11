﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.API.DbContexts;

#nullable disable

namespace Reservation.API.Migrations
{
    [DbContext(typeof(ReservationDbContext))]
    [Migration("20230902133628_addseeddata")]
    partial class addseeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Reservation.API.Model.School", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.HasIndex("UserGuid")
                        .IsUnique();

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("6725d8b7-6fe4-4d71-83a7-720f8ba41779"),
                            Address = "Heravi, Mohammadi, p12",
                            Name = "Allame Helli",
                            UserGuid = new Guid("f340bf05-8262-424a-ad70-577d9c4b8a91")
                        });
                });

            modelBuilder.Entity("Reservation.API.Model.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Guid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("f340bf05-8262-424a-ad70-577d9c4b8a91"),
                            EmailAddress = "Mehran@bazidid.com",
                            Name = "Mehran Ahmadi",
                            PhoneNumber = "09127959333",
                            Role = 0
                        });
                });

            modelBuilder.Entity("Reservation.API.Model.School", b =>
                {
                    b.HasOne("Reservation.API.Model.User", "Manger")
                        .WithOne("School")
                        .HasForeignKey("Reservation.API.Model.School", "UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manger");
                });

            modelBuilder.Entity("Reservation.API.Model.User", b =>
                {
                    b.Navigation("School");
                });
#pragma warning restore 612, 618
        }
    }
}
