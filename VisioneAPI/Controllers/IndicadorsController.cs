using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisioneAPI.Data;
using VisioneAPI.Models;

namespace VisioneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicadorsController : ControllerBase
    {
        private readonly VisioneContext _context;

        public IndicadorsController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/Indicadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indicador>>> GetIndicador()
        {
            return await _context.Indicador.ToListAsync();
        }

        // GET: api/Indicadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indicador>> GetIndicador(int id)
        {
            var indicador = await _context.Indicador.FindAsync(id);

            if (indicador == null)
            {
                return NotFound();
            }

            return indicador;
        }

        // PUT: api/Indicadors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndicador(int id, Indicador indicador)
        {
            if (id != indicador.Id)
            {
                return BadRequest();
            }

            _context.Entry(indicador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndicadorExists(id))
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

        // POST: api/Indicadors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Indicador>> PostIndicador(Indicador indicador)
        {
            _context.Indicador.Add(indicador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicador", new { id = indicador.Id }, indicador);
        }

        // DELETE: api/Indicadors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Indicador>> DeleteIndicador(int id)
        {
            var indicador = await _context.Indicador.FindAsync(id);
            if (indicador == null)
            {
                return NotFound();
            }

            _context.Indicador.Remove(indicador);
            await _context.SaveChangesAsync();

            return indicador;
        }

        private bool IndicadorExists(int id)
        {
            return _context.Indicador.Any(e => e.Id == id);
        }
    }
}
