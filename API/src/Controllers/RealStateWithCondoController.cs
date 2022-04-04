using API.src.Controllers.ViewModels;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateWithCondoController : ControllerBase
    {
        private readonly IRealStateService<RealStateWithCondo> _service;

        public RealStateWithCondoController(IRealStateService<RealStateWithCondo> _serviceCondo) {
            this._service = _serviceCondo;
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RealStateWithCondo>> Details(int id)
        {
            var request = await _service.GetByID(id);
            return request == null ? NotFound() : request;
        }

        [HttpGet]
        [Authorize]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<RealStateWithCondo>>> GetALL() => await _service.GetList();

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, RealStateWithCondo body)
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
        public async Task<ActionResult> Create(RealStateWithCondoViewModels body)
        {
            if (body.realState. ID != null || body.realState.Adress.ID != null) return BadRequest("A ID é gerada automaticamente");

            try
            {
                RealStateWithCondo fromViewModel = body.realState as RealStateWithCondo;
                fromViewModel.Condominio.ID = body.idCondominio;

                 RealStateWithCondo createdObject = await _service.Create(fromViewModel);

                if (createdObject == null) return BadRequest();

                return Created("CreateRealState", new { id = createdObject.ID });

            }
            catch (Exception e) { return BadRequest(e.Message); }
        }



    }
}
