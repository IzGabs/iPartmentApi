
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Controllers.ViewModels;
using API.src.Domain.Monetary;

namespace API.Controllers.RealState
{
    [Route("api/RealState/condo")]
    [ApiController]
    public class RealStateCondoController : ControllerBase
    {
        private readonly IRealStateCondoService _service;

        public RealStateCondoController(IRealStateCondoService service)
        {
            this._service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RealStateCondo>> Details(int id)
        {
            var request = await _service.GetByID(id);
            return request == null ? NotFound() : request;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(RealStateCondoRequest body)
        {

            if (body.realState.ID != null) return BadRequest("A ID é gerada automaticamente");

            try
            {
                var createdObject = await _service.Create(body.realState, body.condoId);

                if (createdObject == null) return BadRequest();

                return Created("CreateRealState", new { id = createdObject.ID });

            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}

