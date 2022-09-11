using API.src.Application.ScheduledVisits;
using API.src.Domain.ScheduledVisits.Application;
using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection.LayerInjectors
{
    public class ScheduledVisitisInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<ScheduleVisitsMapper, ScheduleVisitsMapper>();
            services.AddTransient<IScheduledVisitsService, ScheduledVisitsService>();
            services.AddTransient<IScheduledVisitsRepository, ScheduledVisitsRepository>();
            services.AddTransient<ScheduleVisitsMessageDispatch, ScheduleVisitsMessageDispatch>();
        }
    }
}