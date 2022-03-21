using API.dependencyInjection;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ContextTestClass : IDisposable
    {
        public DbContextOptions<BuildContext> options;
        public BuildContext buildContext { get; private set; }


        public ContextTestClass()
        {
            options = new DbContextOptionsBuilder<BuildContext>().
               UseInMemoryDatabase(databaseName: "testDB")
               .Options;

            buildContext = new BuildContext(options);


           
        }


        public void Dispose()
        {
            buildContext.Dispose();
        }
    }
}
