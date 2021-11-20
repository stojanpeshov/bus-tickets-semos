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
    [Migration("20211119175255_SeatsMigration")]
    partial class SeatsMigration
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

                    b.Property<int?>("BusCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("LaneId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeTableId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("BusCapacity");

                    b.HasIndex("LaneId");

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

                    b.Property<int?>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("BusId");

                    b.ToTable("BusCompanies");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusLanes", b =>
                {
                    b.Property<int>("LaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LaneId");

                    b.HasIndex("BusId");

                    b.ToTable("BusLanes");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusStations", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusLines")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
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

                    b.Property<string>("BusDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusStartPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeTableId");

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

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Cities", b =>
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

                    b.Property<string>("SeatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

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
                    b.HasOne("DataAccessLayer.Entities.Buses", "BusSeats")
                        .WithMany()
                        .HasForeignKey("BusCapacity");

                    b.HasOne("DataAccessLayer.Entities.BusLanes", "Lane")
                        .WithMany()
                        .HasForeignKey("LaneId");

                    b.HasOne("DataAccessLayer.Entities.BusTimeTables", "TimeTable")
                        .WithMany()
                        .HasForeignKey("TimeTableId");

                    b.HasOne("DataAccessLayer.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("BusSeats");

                    b.Navigation("Lane");

                    b.Navigation("TimeTable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusCompanies", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Buses", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusLanes", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Buses", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.BusStations", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Cities", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
