﻿// <auto-generated />
using FlashParkMVP.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlashParkMVP.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20211122025426_seedData")]
    partial class seedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlashParkMVP.DataModels.ParkingLot", b =>
                {
                    b.Property<int>("ParkingLotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParkingLotAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParkingLotId");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("ParkingLots");

                    b.HasData(
                        new
                        {
                            ParkingLotId = 2,
                            ParkingLotAddress = "Garage1"
                        },
                        new
                        {
                            ParkingLotId = 3,
                            ParkingLotAddress = "Garage2"
                        },
                        new
                        {
                            ParkingLotId = 1,
                            ParkingLotAddress = "Garage3"
                        });
                });

            modelBuilder.Entity("FlashParkMVP.DataModels.ParkingSpace", b =>
                {
                    b.Property<int>("ParkingSpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingLotId")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpaceId");

                    b.HasIndex("ParkingLotId");

                    b.HasIndex("ParkingSpaceId");

                    b.ToTable("ParkingSpaces");

                    b.HasData(
                        new
                        {
                            ParkingSpaceId = 1,
                            IsAvailable = true,
                            ParkingLotId = 1
                        },
                        new
                        {
                            ParkingSpaceId = 2,
                            IsAvailable = false,
                            ParkingLotId = 1
                        },
                        new
                        {
                            ParkingSpaceId = 3,
                            IsAvailable = true,
                            ParkingLotId = 1
                        },
                        new
                        {
                            ParkingSpaceId = 4,
                            IsAvailable = false,
                            ParkingLotId = 1
                        },
                        new
                        {
                            ParkingSpaceId = 5,
                            IsAvailable = true,
                            ParkingLotId = 1
                        },
                        new
                        {
                            ParkingSpaceId = 6,
                            IsAvailable = true,
                            ParkingLotId = 2
                        },
                        new
                        {
                            ParkingSpaceId = 7,
                            IsAvailable = false,
                            ParkingLotId = 2
                        },
                        new
                        {
                            ParkingSpaceId = 8,
                            IsAvailable = true,
                            ParkingLotId = 2
                        },
                        new
                        {
                            ParkingSpaceId = 9,
                            IsAvailable = true,
                            ParkingLotId = 2
                        },
                        new
                        {
                            ParkingSpaceId = 10,
                            IsAvailable = true,
                            ParkingLotId = 2
                        },
                        new
                        {
                            ParkingSpaceId = 11,
                            IsAvailable = false,
                            ParkingLotId = 3
                        },
                        new
                        {
                            ParkingSpaceId = 12,
                            IsAvailable = false,
                            ParkingLotId = 3
                        },
                        new
                        {
                            ParkingSpaceId = 13,
                            IsAvailable = true,
                            ParkingLotId = 3
                        });
                });

            modelBuilder.Entity("FlashParkMVP.DataModels.ParkingSpace", b =>
                {
                    b.HasOne("FlashParkMVP.DataModels.ParkingLot", "ParkingLot")
                        .WithMany("ParkingSpaces")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingLot");
                });

            modelBuilder.Entity("FlashParkMVP.DataModels.ParkingLot", b =>
                {
                    b.Navigation("ParkingSpaces");
                });
#pragma warning restore 612, 618
        }
    }
}