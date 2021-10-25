using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DockerAPIEntity.Models
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options): base(options){ }

        public DbSet<User> Users { get; set; }
    }

}
