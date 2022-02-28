using API.src.Application.Condominium;
using API.src.Domain.Condominium;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection.LayerInjectors
{
    public class CondominiumInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<ICondominiumRepository, CondominiumRepository>();
            services.AddTransient<ICondominiumService, CondominiumService>();
        }
    }
}
