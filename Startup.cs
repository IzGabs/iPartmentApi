using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerAPIEntity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DockerAPIEntity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();


            string server = Configuration["DB_HOST"];
            string mySqlConnection = $"server={server}; {Configuration.GetConnectionString("db")}";


            Console.WriteLine("--------------->" + mySqlConnection);


            services.AddDbContextPool<BuildContext>(
             options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));


            services.AddDbContext<DbContext, BuildContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DockerAPIEntity", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BuildContext context)
        {

            context.Database.Migrate();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DockerAPIEntity v1");
                c.RoutePrefix = "api";
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
         {
             endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}");
         });
        }
    }
}
