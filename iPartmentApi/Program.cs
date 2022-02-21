
using API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DockerAPIEntity
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().MigrateDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}

