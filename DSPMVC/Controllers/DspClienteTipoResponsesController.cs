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
    public class DspClienteTipoResponsesController : ControllerBase
    {
        private readonly GpsTcasablancaOpContext _context;

        public DspClienteTipoResponsesController(GpsTcasablancaOpContext context)
        {
            _context = context;
        }

        [HttpGet("Procedure/")]
        public async Task<List<DspClienteTipoResponse>> GetFunction()
        {
            var value = await _context.DspClienteTipoResponse.FromSql($"EXEC [DSP_LIST_CLIENTE_TIPO] ").ToListAsync();
            return value;
        }

        private bool DspClienteTipoResponseExists(int id)
        {
            return _context.DspClienteTipoResponse.Any(e => e.CliTipoClienteID == id);
        }
    }
}
