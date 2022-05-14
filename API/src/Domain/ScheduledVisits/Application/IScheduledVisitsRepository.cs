using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using System.Collections.Generic;

namespace API.src.Domain.ScheduledVisits.Application
{
    public interface IScheduledVisitsRepository
    {
        void Add(ScheduledVisitsObject scheduledVisits);
        void Update(ScheduledVisitsObject scheduledVisits); 
        ScheduledVisitsObject GetApartmentById(int id);  
        void Delete(int id);
        IEnumerable<ScheduledVisitsObject> GetAllVisitsOfUsers(int id);

    }
}
