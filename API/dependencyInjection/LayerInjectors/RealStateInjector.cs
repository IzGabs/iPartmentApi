using API.Application;
using API.src.Application.RealState;
using API.src.Application.RealState.Repository;
using API.src.Application.RealState.Services;
using API.src.Domain.RealState.Application;
using Microsoft.Extensions.DependencyInjection;

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


            services.AddTransient<IRealEstateImagesService, RealEstateImagesService>();
            services.AddTransient<IRealEstateImagesRepository, RealEstateImagesRepository>();


        }
    }
}
