
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iPartmentApi.Domain.RealState;
using API.Domain.RealState;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.RealState
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateController : ControllerBase
    {

        private readonly BuildContext _context;

        public RealStateController(BuildContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RealStateObject>> Details(int id)
        {
            var realStateSearch = await _context.RealState.FindAsync(id);

            if (realStateSearch == null) return NotFound();

            return realStateSearch;
        }

        [HttpGet]
        [Authorize]
        [Route("realStates")]
        public async Task<ActionResult<IEnumerable<RealStateObject>>> GetALL() => await _context.RealState.ToListAsync();


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RealStateObject body)
        {
            if (body.ID != null) return BadRequest("A ID é gerada automaticamente");

            // var _validateRealState = 

            return null;
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, RealStateObject body)
        {
            return null;
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return null;
        }

       
    }
}
