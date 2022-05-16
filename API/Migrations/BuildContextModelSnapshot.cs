﻿// <auto-generated />
using System;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(BuildContext))]
    partial class BuildContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("API.Domain.Location.Address", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.CondominiumObject", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Gym")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ValuesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("ValuesID");

                    b.ToTable("Condominiums");
                });

            modelBuilder.Entity("API.Domain.User.UserObject", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.src.Domain.Announcement.Entities.AnnouncementAggregate", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AdvertiserID")
                        .HasColumnType("int");

                    b.Property<int>("AnnouncementRentId")
                        .HasColumnType("int");

                    b.Property<int>("AnnouncementSellId")
                        .HasColumnType("int");

                    b.Property<int?>("RealEstateID")
                        .HasColumnType("int");

                    b.Property<int?>("RealEstateValuesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("immediatelyAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("AdvertiserID");

                    b.HasIndex("AnnouncementRentId")
                        .IsUnique();

                    b.HasIndex("AnnouncementSellId")
                        .IsUnique();

                    b.HasIndex("RealEstateID");

                    b.HasIndex("RealEstateValuesID");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("API.src.Domain.Announcement.Entities.AnnouncementRentType", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AnnouncementsToRent");
                });

            modelBuilder.Entity("API.src.Domain.Announcement.Entities.AnnouncementSellType", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AnnouncementsToSell");
                });

            modelBuilder.Entity("API.src.Domain.Monetary.Entities.AnnouncementRentMonetary", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("IPTU")
                        .HasColumnType("float");

                    b.Property<float>("montlyValue")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("AnnouncementRentMonetary");
                });

            modelBuilder.Entity("API.src.Domain.Monetary.Entities.AnnouncementSellMonetary", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("value")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("AnnouncementSellMonetary");
                });

            modelBuilder.Entity("API.src.Domain.RealEstate.Entities.Aggregates.RealEstateImages", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("RealEstateID")
                        .HasColumnType("int");

                    b.Property<string>("createdAt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("pathToFile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("RealEstateID");

                    b.ToTable("RealEstateImages");
                });

            modelBuilder.Entity("API.src.Domain.RealState.Entities.TypeRealEstate", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("RealEstateTypes");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Description = "",
                            Name = "APARTMENT"
                        },
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "HOUSE"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "KITNET"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "STUDIO"
                        });
                });

            modelBuilder.Entity("API.src.Domain.RealState.Entities.ValueObject.RealEstateValueObject", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AllowPets")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Furnished")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Garage")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("RoomWithBathroom")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<int>("squareMeters")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("RealEstates");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RealEstateValueObject");
                });

            modelBuilder.Entity("API.src.Domain.User.UsersImages", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("createdAt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("pathToFile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UsersImages");
                });

            modelBuilder.Entity("API.src.Domain.Values.CondominiumMonetary", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("fireInsurence")
                        .HasColumnType("float");

                    b.Property<float>("montlyValue")
                        .HasColumnType("float");

                    b.Property<float?>("serviceCharge")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("CondominiumMonetary");
                });

            modelBuilder.Entity("API.src.Domain.Visit.ScheduledVisit", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("realStateID")
                        .HasColumnType("int");

                    b.Property<int?>("visitorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("realStateID");

                    b.HasIndex("visitorID");

                    b.ToTable("ScheduledVisits");
                });

            modelBuilder.Entity("API.src.Domain.RealState.Entities.RealEstateBase", b =>
                {
                    b.HasBaseType("API.src.Domain.RealState.Entities.ValueObject.RealEstateValueObject");

                    b.Property<int?>("AdressID")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentResidentID")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasIndex("AdressID");

                    b.HasIndex("CurrentResidentID");

                    b.HasIndex("TypeId");

                    b.ToTable("RealEstates");

                    b.HasDiscriminator().HasValue("RealEstateBase");
                });

            modelBuilder.Entity("API.src.Domain.RealState.Entities.RealEstateCondo", b =>
                {
                    b.HasBaseType("API.src.Domain.RealState.Entities.RealEstateBase");

                    b.Property<int>("CondominiumID")
                        .HasColumnType("int");

                    b.HasIndex("CondominiumID");

                    b.ToTable("RealEstates");

                    b.HasDiscriminator().HasValue("RealEstateCondo");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.CondominiumObject", b =>
                {
                    b.HasOne("API.Domain.Location.Address", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("API.src.Domain.Values.CondominiumMonetary", "Values")
                        .WithMany()
                        .HasForeignKey("ValuesID");

                    b.Navigation("Location");

                    b.Navigation("Values");
                });

            modelBuilder.Entity("API.src.Domain.Announcement.Entities.AnnouncementAggregate", b =>
                {
                    b.HasOne("API.Domain.User.UserObject", "Advertiser")
                        .WithMany()
                        .HasForeignKey("AdvertiserID");

                    b.HasOne("API.src.Domain.Announcement.Entities.AnnouncementRentType", "AnnouncementRent")
                        .WithOne("Aggregate")
                        .HasForeignKey("API.src.Domain.Announcement.Entities.AnnouncementAggregate", "AnnouncementRentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.src.Domain.Announcement.Entities.AnnouncementSellType", "AnnouncementSell")
                        .WithOne("Aggregate")
                        .HasForeignKey("API.src.Domain.Announcement.Entities.AnnouncementAggregate", "AnnouncementSellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.src.Domain.RealState.Entities.RealEstateBase", "RealEstate")
                        .WithMany()
                        .HasForeignKey("RealEstateID");

                    b.HasOne("API.src.Domain.Monetary.Entities.AnnouncementSellMonetary", "RealEstateValues")
                        .WithMany()
                        .HasForeignKey("RealEstateValuesID");

                    b.Navigation("Advertiser");

                    b.Navigation("AnnouncementRent");

                    b.Navigation("AnnouncementSell");

                    b.Navigation("RealEstate");

                    b.Navigation("RealEstateValues");
                });

            modelBuilder.Entity("API.src.Domain.RealEstate.Entities.Aggregates.RealEstateImages", b =>
                {
                    b.HasOne("API.src.Domain.RealState.Entities.RealEstateBase", "RealEstate")
                        .WithMany()
                        .HasForeignKey("RealEstateID");

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("API.src.Domain.User.UsersImages", b =>
                {
                    b.HasOne("API.Domain.User.UserObject", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.src.Domain.Visit.ScheduledVisit", b =>
                {
                    b.HasOne("API.src.Domain.RealState.Entities.RealEstateBase", "realState")
                        .WithMany()
                        .HasForeignKey("realStateID");

                    b.HasOne("API.Domain.User.UserObject", "visitor")
                        .WithMany()
                        .HasForeignKey("visitorID");

                    b.Navigation("realState");

                    b.Navigation("visitor");
                });

            modelBuilder.Entity("API.src.Domain.RealState.Entities.RealEstateBase", b =>
                {
                    b.HasOne("API.Domain.Location.Address", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressID");

                    b.HasOne("API.Domain.User.UserObject", "CurrentResident")
                        .WithMany()
                        .HasForeignKey("CurrentResidentID");

                    b.HasOne("API.src.Domain.RealState.Entities.TypeRealEstate", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");

                    b.Navigation("CurrentResident");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("API.src.Domain.RealState.Entities.RealEstateCondo", b =>
                {
                    b.HasOne("API.Domain.RealState.Models.CondominiumObject", "Condominium")
                        .WithMany("realStates")
                        .HasForeignKey("CondominiumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominium");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.CondominiumObject", b =>
                {
                    b.Navigation("realStates");
                });

            modelBuilder.Entity("API.src.Domain.Announcement.Entities.AnnouncementRentType", b =>
                {
                    b.Navigation("Aggregate")
                        .IsRequired();
                });

            modelBuilder.Entity("API.src.Domain.Announcement.Entities.AnnouncementSellType", b =>
                {
                    b.Navigation("Aggregate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
