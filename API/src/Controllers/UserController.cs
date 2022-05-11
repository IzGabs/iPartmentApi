using System;
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
using API.src.Domain.User.Application;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BuildContext _context;
        private readonly IUserService service;

        public UserController(BuildContext context, IUserService service)
        {
            this.service = service;
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
        public async Task<ActionResult<IEnumerable<UserObject>>> GetUsers() => await service.GetAll();


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserObject>> GetUser(int id)
        {
            var request = await service.Get(id);
            return request == null ? NotFound() : request;
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
            var createdUser = service.Create(user);

            if (createdUser == null) return BadRequest();

            return CreatedAtAction("GetUser", new { id = createdUser.Id });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int id, UserObject user)
        {
            var userObject = await service.Get(id);
            if (userObject == null) return NoContent();

            var request = await service.Update(user);
            if (request) return Ok();

            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await service.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            var removeRequest = await service.Delete(user);
            if (removeRequest) return Ok();

            return NoContent();
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
