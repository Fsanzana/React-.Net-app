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
    public class ClientesDispatcherOpcsController : ControllerBase
    {
        private readonly GpsTcasablancaOpContext _context;

        public ClientesDispatcherOpcsController(GpsTcasablancaOpContext context)
        {
            _context = context;
        }

        // GET: api/ClientesDispatcherOpcs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesDispatcherOpc>>> GetClientesDispatcherOpcs()
        {
            return await _context.ClientesDispatcherOpcs.ToListAsync();
        }

        // GET: api/ClientesDispatcherOpcs/1052531
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientesDispatcherOpc>> GetClientesDispatcherOpc(string id)
        {
            var clientesDispatcherOpc = await _context.ClientesDispatcherOpcs.FindAsync(id);

            if (clientesDispatcherOpc == null)
            {
                return NotFound();
            }

            return clientesDispatcherOpc;
        }

        
        // PUT: api/ClientesDispatcherOpcs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientesDispatcherOpc(string id, ClientesDispatcherOpc clientesDispatcherOpc)
        {
            if (id != clientesDispatcherOpc.CliCod)
            {
                return BadRequest();
            }

            _context.Entry(clientesDispatcherOpc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesDispatcherOpcExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientesDispatcherOpcs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientesDispatcherOpc>> PostClientesDispatcherOpc(ClientesDispatcherOpc clientesDispatcherOpc)
        {
            _context.ClientesDispatcherOpcs.Add(clientesDispatcherOpc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientesDispatcherOpcExists(clientesDispatcherOpc.CliCod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientesDispatcherOpc", new { id = clientesDispatcherOpc.CliCod }, clientesDispatcherOpc);
        }

        // DELETE: api/ClientesDispatcherOpcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientesDispatcherOpc(string id)
        {
            var clientesDispatcherOpc = await _context.ClientesDispatcherOpcs.FindAsync(id);
            if (clientesDispatcherOpc == null)
            {
                return NotFound();
            }

            _context.ClientesDispatcherOpcs.Remove(clientesDispatcherOpc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesDispatcherOpcExists(string id)
        {
            return _context.ClientesDispatcherOpcs.Any(e => e.CliCod == id);
        }
    }
}
