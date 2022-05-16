using API.Domain.User;
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

        public async Task<UserObject> Create(UserObject obj)
        {
            try
            {
                var request = await _context.Users.AddAsync(obj);
                await _context.SaveChangesAsync();

                return request.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;

        }

        public async Task<bool> Delete(UserObject body)
        {
            try
            {
                var removed = _context.Users.Remove(body);
                await _context.SaveChangesAsync();
                return removed.State == EntityState.Deleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<UserObject> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user ?? throw null;
        }

        public async Task<List<UserObject>> GetAll() => await _context.Users.ToListAsync();

        public async Task<bool> Update(UserObject obj)
        {
            try
            {
                var updatedUser = _context.Users.Update(obj);
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
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
