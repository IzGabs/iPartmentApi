using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

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
