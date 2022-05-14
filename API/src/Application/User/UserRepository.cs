using API.Domain.User;
using API.src.Domain.User.Application;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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


        public UserObject Get(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<UserObject> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(UserObject obj)
        {
            try
            {
                _context.Users.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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

        public void Delete(UserObject body)
        {
            try
            {
                _context.Users.Remove(body);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private async Task<UserResponsesEnum?> validateUser(UserObject user)
        {
            var searchUser = await _context.Users.FirstOrDefaultAsync(e =>
             e.ID == user.ID ||
             e.Email == user.Email ||
             e.Phone == user.Phone
             );

            var returns = user.IsEqual(searchUser);

            return returns;
        }

        private bool UserExists(UserObject user)
        {
            return _context.Users.Any(e =>
             e.ID == user.ID ||
             e.Email == user.Email ||
             e.Phone == user.Phone
             );
        }
    }
}
