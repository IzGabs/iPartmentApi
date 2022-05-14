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
        public ActionResult<IEnumerable<string>> GetUsers()
        {
            return Ok(service.GetAll());
        }


        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<string> GetUser(int id)
        {
            return Ok(service.Get(id));
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] UserObject user)
        {
            try
            {
                service.Create(user);
                return Ok("Cliente Cadastrado!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public  ActionResult PutUser([FromBody] UserObject user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try {
                service.Update(user);
                return Ok("Cliente Atualizado!");
            }
            catch (Exception)
            {
                throw;
            }
                
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var userobj = service.Get(id);

                service.Delete(userobj);
                return Ok("Cliente Removido!");
            }
            catch (Exception)
            {
                throw;
            } 
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
