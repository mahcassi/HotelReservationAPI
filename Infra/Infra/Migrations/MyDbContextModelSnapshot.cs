﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entity.Entity.AddressHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("AddressHotel", (string)null);
                });

            modelBuilder.Entity("Entity.Entity.AmenityHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AmenityHotels");
                });

            modelBuilder.Entity("Entity.Entity.AmenityRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AmenityRooms");
                });

            modelBuilder.Entity("Entity.Entity.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Guest", (string)null);
                });

            modelBuilder.Entity("Entity.Entity.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Entity.Entity.HotelAmenity", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("HotelAmenities");
                });

            modelBuilder.Entity("Entity.Entity.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("DateTime");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("NumberPeople")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Reservations", (string)null);
                });

            modelBuilder.Entity("Entity.Entity.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Availability")
                        .HasColumnType("BIT");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("Entity.Entity.RoomAmenity", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Entity.Entity.AddressHotel", b =>
                {
                    b.HasOne("Entity.Entity.Hotel", "Hotel")
                        .WithOne("AddressHotel")
                        .HasForeignKey("Entity.Entity.AddressHotel", "HotelId")
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Entity.Entity.HotelAmenity", b =>
                {
                    b.HasOne("Entity.Entity.AmenityHotel", "AmenityHotel")
                        .WithMany("HotelAmenities")
                        .HasForeignKey("AmenityId")
                        .IsRequired();

                    b.HasOne("Entity.Entity.Hotel", "Hotel")
                        .WithMany("HotelAmenities")
                        .HasForeignKey("HotelId")
                        .IsRequired();

                    b.Navigation("AmenityHotel");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Entity.Entity.Reservation", b =>
                {
                    b.HasOne("Entity.Entity.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .IsRequired();

                    b.HasOne("Entity.Entity.Room", "Room")
                        .WithOne("Reservation")
                        .HasForeignKey("Entity.Entity.Reservation", "RoomId")
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Entity.Entity.Room", b =>
                {
                    b.HasOne("Entity.Entity.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Entity.Entity.RoomAmenity", b =>
                {
                    b.HasOne("Entity.Entity.AmenityRoom", "AmenityRoom")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .IsRequired();

                    b.HasOne("Entity.Entity.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .IsRequired();

                    b.Navigation("AmenityRoom");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Entity.Entity.AmenityHotel", b =>
                {
                    b.Navigation("HotelAmenities");
                });

            modelBuilder.Entity("Entity.Entity.AmenityRoom", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Entity.Entity.Guest", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Entity.Entity.Hotel", b =>
                {
                    b.Navigation("AddressHotel")
                        .IsRequired();

                    b.Navigation("HotelAmenities");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Entity.Entity.Room", b =>
                {
                    b.Navigation("Reservation")
                        .IsRequired();

                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
