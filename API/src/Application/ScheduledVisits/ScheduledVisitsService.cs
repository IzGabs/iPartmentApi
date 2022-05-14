using API.src.Domain.ScheduledVisits.Application;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;

namespace API.src.Application.ScheduledVisits
{
    public class ScheduledVisitsService
    {
        private readonly IScheduledVisitsRepository repository;

        public ScheduledVisitsService(IScheduledVisitsRepository repository)
        {
            this.repository = repository;
        }
        public void Add(ScheduledVisitsObject obj)
        {
            repository.Add(obj);
        }

        public void GetAllVisitsOfUsers(int id)
        {
            repository.GetAllVisitsOfUsers(id);
        }

    }
}
