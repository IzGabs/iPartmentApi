using API.src.Domain.RealState.Application;
using API.src.Domain.ScheduledVisits.Application;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Domain.User.Application;

namespace API.src.Application.ScheduledVisits
{
    public class ScheduleVisitsMapper
    {
        private readonly IUserService userService;
        private readonly IRealEstateService realStateService;
        private readonly IScheduledVisitsService scheduleService;


        public ScheduledVisitsObject getMapper(int id)
        {
            var user = userService.Get(id);
            var realState = realStateService.GetByID(id);

            return new ScheduledVisitsObject(
                
                
                );
        }
    }
}
