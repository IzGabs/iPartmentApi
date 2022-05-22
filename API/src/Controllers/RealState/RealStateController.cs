
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers.RealState
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateController : ControllerBase
    {
        private readonly IRealEstateService _service;
        public RealStateController(IRealEstateService service) { this._service = service; }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RealEstateBase>> Details(int id)
        {
            var request = await _service.GetByID(id);
            return request == null ? NotFound() : request;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(RealEstateBase body)
        {
            if (body.isCondoRequired()) return BadRequest("Esse tipo de imóvel requer um condominio");
            if (body.ID != null) return BadRequest("A ID é gerada automaticamente");

            try
            {
                var createdObject = await _service.Create(body);

                if (createdObject == null) return BadRequest();

                return Created("CreateRealState", new { id = createdObject.ID });

            }
            catch (Exception e) { return BadRequest(e.Message); }
        }


    }
}

