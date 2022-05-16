using API.src.Application.Condominium;
using API.src.Application.Condominium.Monetary;
using API.src.Domain.Condominium;
using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Values;
using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection.LayerInjectors
{
    public class CondominiumInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<ICondominiumRepository, CondominiumRepository>();
            services.AddTransient<ICondominiumService, CondominiumService>();

            services.AddTransient<IMonetaryRepository<CondominiumMonetary>, CondoMonetaryRepository>();
            services.AddTransient<IMonetaryService<CondominiumMonetary>, CondoMonetaryService>();
        }
    }
}
