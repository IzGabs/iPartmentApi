﻿using API.Domain.RealState.Models;
using API.src.Domain.Condominium;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiumController : ControllerBase
    {
        private readonly ICondominiumService service;

        public CondominiumController(ICondominiumService thisService){ this.service = thisService;}


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CondominiumObject body)
        {
            if (body.ID != null || body.Location.ID != null) return BadRequest("A ID é gerada automaticamente");

            var request = await service.Create(body);

            return !request ? BadRequest() : Ok();
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CondominiumObject>> Details(int id)
        {
            var request = await service.Get(id);
            return request == null ? NotFound() : request;
        }

        [HttpGet]
        [Authorize]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<CondominiumObject>>> GetAll() => await service.GetAll();


    }
}
