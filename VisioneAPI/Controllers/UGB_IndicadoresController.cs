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
    public class UGB_IndicadoresController : ControllerBase
    {
        private readonly VisioneContext _context;

        public UGB_IndicadoresController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/UGB_Indicadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UGB_Indicadores>>> GetUGB_Indicadores()
        {
            return await _context.UGB_Indicadores.ToListAsync();
        }

        // GET: api/UGB_Indicadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UGB_Indicadores>> GetUGB_Indicadores(int id)
        {
            var uGB_Indicadores = await _context.UGB_Indicadores.FindAsync(id);

            if (uGB_Indicadores == null)
            {
                return NotFound();
            }

            return uGB_Indicadores;
        }
        // GET: api/UGB_Indicadores/UGB/5
        [HttpGet("UGB/{IdUGB}")]
        public async Task<ActionResult<IEnumerable<UGBIndicadorViewModel>>> GetIndicators(long IdUGB)
        {
            return await (from ugbIndicador in _context.UGB_Indicadores
                                join ugb in _context.UGB 
                                    on ugbIndicador.IdUGB equals ugb.Id
                                join indicador in _context.Indicador
                                    on ugbIndicador.IdIndicador equals indicador.Id
                           where ugbIndicador.IdUGB == IdUGB
                           select new UGBIndicadorViewModel { 
                               Id = indicador.Id,
                               IdUGB = ugb.Id,
                               Nome = indicador.Nome,
                               NomeUgb = ugb.Nome,
                               MetodoPreenchimento = indicador.MetodoPreenchimento
                           }).ToListAsync();
        }

        // GET: api/UGB_Indicadores/Indicator/5
        [HttpGet("Indicator/{IdIndicador}")]
        public async Task<ActionResult<IEnumerable<Indicador>>> GetIndicatorData(long IdIndicador)
        {
            return await (from ugbIndicador in _context.UGB_Indicadores
                          join ugb in _context.UGB
                              on ugbIndicador.IdUGB equals ugb.Id
                          join indicador in _context.Indicador
                              on ugbIndicador.IdIndicador equals indicador.Id
                          where ugbIndicador.IdIndicador == IdIndicador
                          select new Indicador
                          {
                              Id = indicador.Id,
                              IdEstabelecimento = indicador.IdEstabelecimento,
                              Nome = indicador.Nome,
                              EscalaMax = indicador.EscalaMax,
                              EscalaMin = indicador.EscalaMin,
                              Meta = ugbIndicador.Meta,
                              ValorMaximo = ugbIndicador.ValorMaximo,
                              ValorMinimo = ugbIndicador.ValorMinimo
                          }).ToListAsync();
        }

        // PUT: api/UGB_Indicadores/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUGB_Indicadores(int id, UGB_Indicadores uGB_Indicadores)
        {
            if (id != uGB_Indicadores.Id)
            {
                return BadRequest();
            }

            _context.Entry(uGB_Indicadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UGB_IndicadoresExists(id))
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

        // POST: api/UGB_Indicadores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UGB_Indicadores>> PostUGB_Indicadores(UGB_Indicadores uGB_Indicadores)
        {
            _context.UGB_Indicadores.Add(uGB_Indicadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUGB_Indicadores", new { id = uGB_Indicadores.Id }, uGB_Indicadores);
        }

        // DELETE: api/UGB_Indicadores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UGB_Indicadores>> DeleteUGB_Indicadores(int id)
        {
            var uGB_Indicadores = await _context.UGB_Indicadores.FindAsync(id);
            if (uGB_Indicadores == null)
            {
                return NotFound();
            }

            _context.UGB_Indicadores.Remove(uGB_Indicadores);
            await _context.SaveChangesAsync();

            return uGB_Indicadores;
        }

        private bool UGB_IndicadoresExists(int id)
        {
            return _context.UGB_Indicadores.Any(e => e.Id == id);
        }
    }
}
