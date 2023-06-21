﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Airport", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureAirportId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureAirportId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("DepartureAirportId");

                    b.HasIndex("DepartureAirportId1");

                    b.ToTable("Flight", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.GPSLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("GPSLocation", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Airport", b =>
                {
                    b.HasOne("Domain.Entities.GPSLocation", "Location")
                        .WithOne("Airport")
                        .HasForeignKey("Domain.Entities.Airport", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.HasOne("Domain.Entities.Airport", "ArrivalAirport")
                        .WithMany("ArrivalAirportFlights")
                        .HasForeignKey("DepartureAirportId");

                    b.HasOne("Domain.Entities.Airport", "DepartureAirport")
                        .WithMany("DepartureAirportFlights")
                        .HasForeignKey("DepartureAirportId1");

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");
                });

            modelBuilder.Entity("Domain.Entities.Airport", b =>
                {
                    b.Navigation("ArrivalAirportFlights");

                    b.Navigation("DepartureAirportFlights");
                });

            modelBuilder.Entity("Domain.Entities.GPSLocation", b =>
                {
                    b.Navigation("Airport");
                });
#pragma warning restore 612, 618
        }
    }
}
