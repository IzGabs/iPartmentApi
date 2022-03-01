using Microsoft.Extensions.DependencyInjection;
using API.Application;
using API.src.Application.RealState;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;

namespace API.dependencyInjection
{
    public class RealStateInjector : ILayerInjector
    {
        public RealStateInjector() { }

        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IRealStateRepository<RealStateObject>, RealStateRepository>();
            services.AddTransient<IRealStateService<RealStateObject>, RealStateService>();

            services.AddTransient<IRealStateRepository<RealStateWithCondo>, RealStateWithCondoRepository>();
            services.AddTransient<IRealStateService<RealStateWithCondo>, RealStateWithCondoService>();

        }
    }
}
