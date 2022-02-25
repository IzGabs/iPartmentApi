using API.Domain.User;
using API.Domain.Location;
using API.Domain.RealState.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Domain.Models
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options) : base(options) { 
        }

        public DbSet<UserObject> Users { get; set; }
        public DbSet<Condominium> Condominium { get; set; }
        public DbSet<RealStateObject> RealState { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }

}
