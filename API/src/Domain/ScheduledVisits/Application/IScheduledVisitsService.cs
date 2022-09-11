using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.ScheduledVisits.Application
{
    public interface IScheduledVisitsService
    {
        public Task<bool> Add(ScheduledVisitDTO obj);
        ScheduledVisitsObject GetById(int id);
        IEnumerable<ScheduledVisitsObject> GetAllVisitsOfUsers(int id);
        IEnumerable<ScheduledVisitsObject> GetAllVisitsOfAgent(int id);
        IEnumerable<ScheduledVisitsObject> GetAllScheduledVisitsFromAnnounce(int id);
    }
}
