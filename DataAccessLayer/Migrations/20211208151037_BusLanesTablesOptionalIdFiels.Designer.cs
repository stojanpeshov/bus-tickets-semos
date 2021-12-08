﻿// <auto-generated />
using System;
using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211208151037_BusLanesTablesOptionalIdFiels")]
    partial class BusLanesTablesOptionalIdFiels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.Bookings", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("TimeTableId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("TimeTableId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusCompanies", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("BusCompanies");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusLane", b =>
                {
                    b.Property<int>("LaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusDestinationId")
                        .HasColumnType("int");

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int?>("BusStartPointId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LaneId");

                    b.HasIndex("BusDestinationId");

                    b.HasIndex("BusId");

                    b.HasIndex("BusStartPointId");

                    b.HasIndex("CityId");

                    b.ToTable("BusLanes");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusStations", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("StationId");

                    b.HasIndex("CityId");

                    b.ToTable("BusStations");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusTimeTables", b =>
                {
                    b.Property<int>("TimeTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BusArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BusDepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BusLaneLaneId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeTableId");

                    b.HasIndex("BusLaneLaneId");

                    b.HasIndex("CompanyId");

                    b.ToTable("BusTimeTables");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Buses", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusCapacity")
                        .HasColumnType("int");

                    b.Property<string>("BusType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Seats", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("BusId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Bookings", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.BusTimeTables", "TimeTable")
                        .WithMany()
                        .HasForeignKey("TimeTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeTable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusLane", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.BusStations", "BusDestination")
                        .WithMany()
                        .HasForeignKey("BusDestinationId");

                    b.HasOne("DataAccessLayer.Entities.Buses", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.BusStations", "BusStartPoint")
                        .WithMany()
                        .HasForeignKey("BusStartPointId");

                    b.HasOne("DataAccessLayer.Entities.City", null)
                        .WithMany("BusLanes")
                        .HasForeignKey("CityId");

                    b.Navigation("Bus");

                    b.Navigation("BusDestination");

                    b.Navigation("BusStartPoint");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusStations", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusTimeTables", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.BusLane", "BusLane")
                        .WithMany()
                        .HasForeignKey("BusLaneLaneId");

                    b.HasOne("DataAccessLayer.Entities.BusCompanies", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusLane");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Buses", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.BusCompanies", "Company")
                        .WithMany("Buses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Seats", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Buses", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusCompanies", b =>
                {
                    b.Navigation("Buses");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.City", b =>
                {
                    b.Navigation("BusLanes");
                });
#pragma warning restore 612, 618
        }
    }
}