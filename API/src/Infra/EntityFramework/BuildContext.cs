using API.Domain.User;
using API.Domain.Location;
using API.Domain.RealState.Models;
using Microsoft.EntityFrameworkCore;
using API.src.Domain.Values;
using API.src.Domain.RealState.Entities;
using API.src.Domain.Monetary.Entities;

namespace API.src.Infra.EntityFramework
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options) : base(options) { }

        public DbSet<UserObject> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<RealStateObject> RealState { get; set; }
        public DbSet<RealStateCondo> RealStateCondo { get; set; }
        public DbSet<RealStateMonetary> RealStateMonetary { get; set; }

        public DbSet<CondominiumObject> Condominium { get; set; }
        public DbSet<CondominiumMonetary> CondominiumValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CondominiumObject>()
                .HasMany(c => c.realStates)
                .WithOne(e => e.Condominium);
        }
    }

}

