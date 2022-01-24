using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using API.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DockerAPIEntity.Models
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<User> Condominium { get; set; }
        public DbSet<User> RealState { get; set; }

    }

}
