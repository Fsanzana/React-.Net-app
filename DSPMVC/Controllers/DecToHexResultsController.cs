using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSPMVC.Models;

namespace DSPMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecToHexResultsController : ControllerBase
    {
        private readonly GpsTcasablancaOpContext _context;

        public DecToHexResultsController(GpsTcasablancaOpContext context)
        {
            _context = context;
        }

        // GET: api/ClientesDispatcherOpcs/Function/8000
        [HttpGet("Function/{valor}")]
        public async Task<List<DecToHexResult>> GetFunction(string valor)
        {
            var value = await _context.DecToHexResult.FromSql($" SELECT dbo.dec_to_hex({valor}) as Valor; ").ToListAsync();
            return value;
        }

       


        private bool DecToHexResultExists(string id)
        {
            return _context.DecToHexResult.Any(e => e.Valor == id);
        }
    }
}
