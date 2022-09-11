using API.Application;
using API.Domain.User;
using API.src.Controllers.ViewModels;
using API.src.Domain.User;
using API.src.Domain.User.Application;
using API.src.Helpers;
using API.src.Infra.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<string>> GetUsers() => Ok(service.GetAll());


        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<string> GetUser(int id) => Ok(service.Get(id));

        [HttpPost]
        public ActionResult<UserObject> PostUser([FromBody] UserObject user)
        {
            try
            {
                var result = service.Create(user);
                if (result == null) return BadRequest("Erro ao cadastrar usuario");

                result.Password = "";
                return  Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutUser([FromBody] UserObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
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

        [HttpPost]
        [Route("CreateAgent")]
        public async Task<ActionResult> CreateAgent([FromForm] NewAgentViewModel data)
        {
            try
            {
                var converter = new FormFileImageConverter(new UsersImages());
                var newImage = converter.transformSingle(data.image);

                var DTO = new NewAgentDTO(
                   data.CRECIID,
                   newImage,
                   data.userID
                );


                var request = await service.CreateAgent(DTO);

                return Ok();

            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}