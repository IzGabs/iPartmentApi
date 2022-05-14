using API.Domain.Location;
using API.Domain.RealState.Models;
using API.Domain.User;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealEstate.Entities.Aggregates;
using API.src.Domain.RealState.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Domain.User;
using API.src.Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace API.src.Infra.EntityFramework
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options) : base(options) { }

        //Base
        public DbSet<UserObject> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<RealEstateBase> RealEstate { get; set; }
        public DbSet<RealEstateCondo> RealEstateCondo { get; set; }
        public DbSet<TypeRealEstate> RealEstateTypes { get; set; }


        public DbSet<CondominiumObject> Condominium { get; set; }
        public DbSet<CondominiumMonetary> CondominiumValues { get; set; }

        //Operation
        public DbSet<AnnouncementAggregate> Announcements { get; set; }
        public DbSet<AnnouncementRentMonetary> AnnouncementRentMonetary { get; set; }
        public DbSet<AnnouncementSellMonetary> AnnouncementSellMonetary { get; set; }

        public DbSet<ScheduledVisitsObject> ScheduledVisits { get; set; }

        //Images
        public DbSet<UsersImages> UsersImages { get; set; }
        public DbSet<RealEstateImages> RealEstateImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CondominiumObject>()
                .HasMany(c => c.realStates)
                .WithOne(e => e.Condominium);

            modelBuilder.Entity<RealEstateValueObject>().ToTable("RealEstates");

            modelBuilder.Entity<TypeRealEstate>()
                .HasMany<RealEstateBase>()
                .WithOne(x => x.Type);

            modelBuilder.Entity<AnnouncementAggregate>()
               .HasOne(s => s.RentValues)
               .WithOne(e => e.aggregate)
               .HasForeignKey<AnnouncementAggregate>(x => x.AnnouncementRentId);

            modelBuilder.Entity<AnnouncementAggregate>()
              .HasOne(s => s.SellValues)
              .WithOne(e => e.aggregate)
              .HasForeignKey<AnnouncementAggregate>(x => x.AnnouncementSellId);


            Seed(modelBuilder);
        }

        protected void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEnumValues<TypeRealEstate, RealEstateTypesEnum>(@enum => @enum);
        }
    }

}

