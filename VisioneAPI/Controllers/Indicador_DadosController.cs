using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisioneAPI.Data;
using VisioneAPI.Models;

namespace VisioneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Indicador_DadosController : ControllerBase
    {
        private readonly VisioneContext _context;

        public Indicador_DadosController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/Indicador_Dados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indicador_Dados>>> GetIndicador_Dados()
        {
            return await _context.Indicador_Dados.ToListAsync();
        }

        // GET: api/Indicador_Dados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indicador_Dados>> GetIndicador_Dados(int id)
        {
            var indicador_Dados = await _context.Indicador_Dados.FindAsync(id);

            if (indicador_Dados == null)
            {
                return NotFound();
            }

            return indicador_Dados;
        }

        // PUT: api/Indicador_Dados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndicador_Dados(int id, Indicador_Dados indicador_Dados)
        {
            if (id != indicador_Dados.Id)
            {
                return BadRequest();
            }

            _context.Entry(indicador_Dados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Indicador_DadosExists(id))
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

        // POST: api/Indicador_Dados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [System.Web.Http.AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Indicador_Dados>> PostIndicador_Dados(Indicador_Dados indicador_Dados)
        {
            _context.Indicador_Dados.Add(indicador_Dados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicador_Dados", new { id = indicador_Dados.Id }, indicador_Dados);
        }

        /** My element **/
        // POST api/Indicador_Dados/Indicador
        [HttpPost("Indicador")]
        public async Task<ActionResult<IEnumerable<Indicador_Dados>>> PostIndicadorItensDados(IEnumerable<Indicador_Dados> indicatorDados)
        {

            
            
            return CreatedAtAction("GetIndicador_Dados", indicatorDados, indicatorDados);
        }

        // DELETE: api/Indicador_Dados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Indicador_Dados>> DeleteIndicador_Dados(int id)
        {
            var indicador_Dados = await _context.Indicador_Dados.FindAsync(id);
            if (indicador_Dados == null)
            {
                return NotFound();
            }

            _context.Indicador_Dados.Remove(indicador_Dados);
            await _context.SaveChangesAsync();

            return indicador_Dados;
        }

        private bool Indicador_DadosExists(int id)
        {
            return _context.Indicador_Dados.Any(e => e.Id == id);
        }
    }
}
