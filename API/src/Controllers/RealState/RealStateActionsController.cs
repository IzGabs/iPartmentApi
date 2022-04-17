﻿using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers.RealState
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateActionsController : ControllerBase
    {
        private readonly IRealStateService service;

        public RealStateActionsController(IRealStateService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RealStateBase>>> HomeItens([Required] string city, int page)
        {
            var request = await service.GetListPagineted(city, page: page, pageSize: 20);
            return request != null ? request : new EmptyResult();
        }
    }
}
