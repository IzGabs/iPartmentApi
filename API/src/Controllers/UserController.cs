﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Application;
using API.Domain.User;
using API.src.Infra.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
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
        public async Task<ActionResult<dynamic>> Authenticate(LoginViewModel data)
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == data.email);

            if (findUser == null) return NotFound(new { message = "Esse email não está cadastrado!" });

            var passawordValid = findUser.Password == data.password;

            if (!passawordValid) { return Unauthorized(new { message = "Usuario e/ou senha invalidos" }); }

            var token = TokenService.GenerateToken(findUser);

            findUser.Password = "";

            return new { findUser, token };
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserObject>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserObject>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserObject>> PostUser(UserObject user)
        {
            //Do Not provide a ID
            if (user.ID != null) return BadRequest("A ID é gerada automaticamente");

            var validateRegister = await validateUser(user);

            if (validateRegister != null)
            {
                return Conflict(validateRegister.ToString());

            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int id, UserObject user)
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

        private bool UserExists(UserObject user)
        {
            return _context.Users.Any(e =>
             e.ID == user.ID ||
             e.Email == user.Email ||
             e.Phone == user.Phone
             );
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

    }

    public class LoginViewModel
    {
        public LoginViewModel(string email, string password) {
            this.email = email;
            this.password = password;
        }

        [Required]
        public String email { get; set; }
        [Required]
        public String password { get; set; }
    }
}
