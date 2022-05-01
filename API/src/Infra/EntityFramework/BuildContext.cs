using API.Domain.User;
using API.Domain.Location;
using API.Domain.RealState.Models;
using Microsoft.EntityFrameworkCore;
using API.src.Domain.Values;
using API.src.Domain.RealState.Entities;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using System;
using System.Linq;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Visit;

namespace API.src.Infra.EntityFramework
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options) : base(options) { }

        public DbSet<UserObject> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<RealEstateBase> RealEstate { get; set; }
        public DbSet<RealEstateCondo> RealEstateCondo { get; set; }
        public DbSet<TypeRealEstate> RealEstateTypes { get; set; }

        public DbSet<RealStateMonetary> RealStateMonetary { get; set; }

        public DbSet<CondominiumObject> Condominium { get; set; }
        public DbSet<CondominiumMonetary> CondominiumValues { get; set; }

        //Operation
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementRentType> AnnouncementsToRent { get; set; }
        public DbSet<AnnouncementSellType> AnnouncementsToSell { get; set; }

        public DbSet<ScheduledVisit> ScheduledVisits { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CondominiumObject>()
                .HasMany(c => c.realStates)
                .WithOne(e => e.Condominium);

            modelBuilder.Entity<RealEstateValueObject>().ToTable("RealEstates");

            Seed(modelBuilder);
        }

        protected void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEnumValues<TypeRealEstate, RealEstateTypesEnum>(@enum => @enum);
        }
    }

}

