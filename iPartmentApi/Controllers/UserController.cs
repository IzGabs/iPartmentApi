using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DockerAPIEntity.Models;
using Microsoft.AspNetCore.Authorization;
using iPartmentApi;
using API.Domain;
using iPartmentApi.Domain.RealState.RealStateSubTypes;
using API.Domain.User;

namespace DockerAPIEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BuildContext _context;

        public UserController(BuildContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(String email, String password)
        {
            try
            {
                var user = await _context.Users.FirstAsync(x => x.Email == email && x.Password == password);

                if (user == null) { return Unauthorized(new { message = "Usuario e/ou senha invalidos" }); }

                var token = TokenService.GenerateToken(user);

                user.Password = "";

                return new { user, token };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //Do Not provide a ID
            if (user.ID != null) return BadRequest("A ID é gerada automaticamente");

            var validateRegister = await validateUser(user);

            if(validateRegister != null)
            {
                return Conflict(validateRegister.ToString());

            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(User user)
        {
            return _context.Users.Any(e =>
             e.ID == user.ID ||
             e.Email == user.Email ||
             e.Phone == user.Phone
             );
        }

        private async Task<UserResponsesEnum?> validateUser(User user) {
            var searchUser = await _context.Users.FirstOrDefaultAsync(e =>
             e.ID == user.ID ||
             e.Email == user.Email ||
             e.Phone == user.Phone
             );

            var returns =  user.IsEqual(searchUser);

            return returns; 
        }

    }
}
