using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DockerAPIEntity.Models;

namespace DockerAPIEntity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly BuildContext _context;

        private readonly ILogger<PessoasController> _logger;

        public PessoasController(BuildContext context, ILogger<PessoasController> logger) {

            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Pessoa>> Get()
        {
            return await _context.Pessoas.ToListAsync();
        }

        
       

    }
}
