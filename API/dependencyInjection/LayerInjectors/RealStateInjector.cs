using Microsoft.Extensions.DependencyInjection;
using API.Application;
using API.src.Application.RealState;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Application.RealState.Repository;

namespace API.dependencyInjection
{
    public class RealStateInjector : ILayerInjector
    {
        public RealStateInjector() { }

        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IRealEstateRepository, RealStateRepository>();
            services.AddTransient<IRealEstateService, RealStateService>();

            services.AddTransient<IRealEstateCondoService, RealStateCondoService>();
            services.AddTransient<IRealEstateCondoRepository, RealStateCondoRepository>();

            services.AddTransient<IRealEstateGetAdvancedRepository, RealStateGetAdvanced>();

        }
    }
}
