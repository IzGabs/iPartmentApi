using API.src.Infra.Geolocator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection.LayerInjectors.Infra
{
    public class GeolocatorInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddSingleton<GeolocatorClient, GeolocatorClient>();
        }
    }
}
