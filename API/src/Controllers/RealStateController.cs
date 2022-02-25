
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.RealState.Models;
using API.src.Domain.RealState;

namespace API.Controllers.RealState
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateController : ControllerBase
    {

        private readonly IRealStateService _service;

        public RealStateController(IRealStateService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RealStateObject>> Details(int id)
        {
            var request = await _service.GetByID(id);
            return request == null ? NotFound() : request;
        }

        [HttpGet]
        [Authorize]
        [Route("realStates")]
        public async Task<ActionResult<IEnumerable<RealStateObject>>> GetALL() => await _service.GetList();


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(RealStateObject body)
        {
            if (body.ID != null || body.localizacao.ID != null) return BadRequest("A ID é gerada automaticamente");
            RealStateObject createdObject = await _service.Create(body);

            if (createdObject == null) return BadRequest();

            return Created("CreateRealState", new { id = createdObject.ID }); 
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, RealStateObject body)
        {
            var _findInDB = await _service.GetByID(id);
            if (_findInDB == null) return NoContent(); 

            var _request = await _service.Update(body);
            if(_request)return Ok();

            return StatusCode(500);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var _findInDB = await _service.GetByID(id);
            if (_findInDB == null) return NoContent();

            var _request = await _service.Delete(_findInDB);
            if (_request) return Ok();

            return StatusCode(500);
        }


    }
}
