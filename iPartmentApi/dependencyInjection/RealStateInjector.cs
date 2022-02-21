using Microsoft.Extensions.DependencyInjection;
using API.Application;
using iPartmentApi.src.Application.RealState;
using iPartmentApi.src.Domain.RealState.repository;

namespace API.dependencyInjection
{
    public class RealStateInjector : ILayerInjector
    {
        public RealStateInjector() { }

        public void Inject(IServiceCollection services)
        {
            services.AddScoped<IRealStateRepository, RealStateRepository>();
            services.AddTransient<RealStateService, RealStateService>();
        }
    }
}
