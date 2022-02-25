using API.src.Application.Location;
using API.src.Domain.Location;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection
{
    public class LocationInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ILocationService, LocationService>();
        }
    }
}
