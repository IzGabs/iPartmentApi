using API.src.Application.Condominium.Monetary;
using API.src.Application.Monetary.Announcement.Rent;
using API.src.Application.Monetary.Announcement.Sell;
using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.Values;
using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection.LayerInjectors
{
    public class MonetaryInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IMonetaryService<CondominiumMonetary>, CondoMonetaryService>();
            services.AddTransient<IMonetaryRepository<CondominiumMonetary>, CondoMonetaryRepository>();

            services.AddTransient<IMonetaryService<AnnouncementSellMonetary>, AnnouncementSellMonetaryService>();
            services.AddTransient<IMonetaryRepository<AnnouncementSellMonetary>, AnnouncementSellMonetaryRepository>();

            services.AddTransient<IMonetaryService<AnnouncementRentMonetary>, AnnouncementRentMonetaryService>();
            services.AddTransient<IMonetaryRepository<AnnouncementRentMonetary>, AnnouncementRentMonetaryRepository>();
        }
    }
}
