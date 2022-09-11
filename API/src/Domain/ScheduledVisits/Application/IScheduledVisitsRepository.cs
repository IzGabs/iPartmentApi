using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.ScheduledVisits.Application
{
    public interface IScheduledVisitsRepository
    {
        Task<bool> Add(ScheduledVisitsObject scheduledVisits);
        IEnumerable<ScheduledVisitsObject> GetAllVisitsOfUsers(int id);
        IEnumerable<ScheduledVisitsObject> GetAllVisitsOfAgent(int id);
        ScheduledVisitsObject GetById(int id);
        IEnumerable<ScheduledVisitsObject> GetAllScheduledVisitsFromAnnounce(int id);
    }
}
