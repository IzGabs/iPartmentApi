
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.RealState.Models;
using API.src.Domain.RealState;
using API.src.Controllers.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

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
        [Route("list")]
        public async Task<ActionResult<IEnumerable<RealStateObject>>> GetALL() => await _service.GetList();

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, RealStateObject body)
        {
            var _findInDB = await _service.GetByID(id);
            if (_findInDB == null) return NoContent();

            var _request = await _service.Update(body);
            if (_request) return Ok();

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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(RealStateObject body, int? condoID)
        {

            if (body.isCondoRequired() && condoID == null) return BadRequest("Informe a ID do condominio");

            if (body.ID != null || body.localizacao.ID != null) return BadRequest("A ID é gerada automaticamente");

            try
            {
                RealStateObject createdObject = await _service.Create(body, condoID);

                if (createdObject == null) return BadRequest();

                return Created("CreateRealState", new { id = createdObject.ID });

            }
            catch (Exception e) { return BadRequest(e.Message); }
        }








    }

}

