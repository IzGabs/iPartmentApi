using API.src.Application.Condominium.Monetary;
using API.src.Application.Monetary.RealState;
using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.Values;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection.LayerInjectors
{
    public class MonetaryInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IMonetaryService<CondominiumMonetary>, CondoMonetaryService>();
            services.AddTransient<IMonetaryRepository<CondominiumMonetary>, CondoMonetaryRepository>();

            services.AddTransient<IMonetaryService<RealStateMonetary>, RealStateMonetaryService>();
            services.AddTransient<IMonetaryRepository<RealStateMonetary>, RealStateMonetaryRepository>();
        }
    }
}
