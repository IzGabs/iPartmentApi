using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using API.Domain.RealState;
using API.Domain.User;
using iPartmentApi.Domain.Location;
using iPartmentApi.Domain.RealState;
using Microsoft.EntityFrameworkCore;

namespace API.Domain.Models
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options) : base(options) { }

        public DbSet<UserObject> Users { get; set; }
        public DbSet<Condominium> Condominium { get; set; }
        public DbSet<RealStateObject> RealState { get; set; }
        public DbSet<Adress> Addresses { get; set; }

    }

}
