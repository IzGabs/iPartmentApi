using API.src.Application.Announcement;
using API.src.Domain.Announcement.Application;
using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection.LayerInjectors
{
    public class AnnouncementInjector : ILayerInjector
    {

        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IAnnouncementRepository, AnnouncementRepository>();
        }


    }
}
