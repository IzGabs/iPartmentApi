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
            services.AddTransient<IRealStateRepository, RealStateRepository>();
            services.AddTransient<IRealStateService, RealStateService>();

            services.AddTransient<IRealStateCondoService, RealStateCondoService>();
            services.AddTransient<IRealStateCondoRepository, RealStateCondoRepository>();

            services.AddTransient<IRealStateGetAdvancedRepository, RealStateGetAdvanced>();

        }
    }
}
