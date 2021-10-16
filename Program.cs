using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerAPIEntity;
using DockerAPIEntity.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DockerAPIEntity
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var build = CreateHostBuilder(args).Build();
            //ExtensionToIWebHost.MigrateDatabase<BuildContext>(build);
            build.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>{
                webBuilder.UseStartup<Startup>();
             });
        }
    }
}


public static class ExtensionToIWebHost
{
    public static IWebHost MigrateDatabase<T>(this IWebHost webHost) where T : DbContext
    {
        using (var scope = webHost.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<T>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
        return webHost;
    }
}
