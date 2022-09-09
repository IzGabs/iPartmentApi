using API.Domain.User;
using API.src.Domain.User;
using API.src.Domain.User.Application;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.User
{
    public class UserRepository : IUserRepository
    {
        private readonly BuildContext _context;

        public UserRepository(BuildContext context)
        {
            _context = context;
        }


        public UserObject Get(int id) => _context.Users.Find(id);

        public IEnumerable<UserObject> GetAll() => _context.Users.ToList();

        public UserObject Create(UserObject obj)
        {
            try
            {
                var add =  _context.Users.Add(obj);
                _context.SaveChanges();

                return add.Entity;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public void Update(UserObject obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(UserObject id) => throw new NotImplementedException();


        public async Task<bool> CreateAgent(AgentDocument obj)
        {
            var request = await _context.AgentDocuments.AddAsync(obj);
            await _context.SaveChangesAsync();

            return request.State == EntityState.Added;
        }
    }
}
