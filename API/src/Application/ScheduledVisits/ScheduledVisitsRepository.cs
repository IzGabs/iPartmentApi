using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Domain.User.Application;
using API.src.Infra.EntityFramework;
using System;
using System.Linq;

namespace API.src.Application.ScheduledVisits
{
    public class ScheduledVisitsRepository
    {
        private readonly BuildContext _context;
        private readonly IUserService userService;

        public ScheduledVisitsRepository(BuildContext context)
        {
            _context = context;
        }

        public void Add(ScheduledVisitsObject obj)
        {
            try
            {
                _context.ScheduledVisits.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetAllVisitsOfUsers(int id)
        {
            try
            {
                var users = _context.ScheduledVisits.Find(id);
                //_context.ScheduledVisits.ToList(x => x.id = users.id);
                _context.SaveChanges();
                //Pegar o visitors Id
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
