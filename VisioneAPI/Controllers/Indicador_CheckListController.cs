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
    public class Indicador_CheckListController : ControllerBase
    {
        private readonly VisioneContext _context;

        public Indicador_CheckListController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/Indicador_CheckList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indicador_CheckList>>> GetIndicador_CheckList()
        {
            return await _context.Indicador_CheckList.ToListAsync();
        }

        // GET: api/Indicador_CheckList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indicador_CheckList>> GetIndicador_CheckList(int id)
        {
            var indicador_CheckList = await _context.Indicador_CheckList.FindAsync(id);

            if (indicador_CheckList == null)
            {
                return NotFound();
            }

            return indicador_CheckList;
        }

        // GET: api/Indicador_CheckList/Indicador/5
        [HttpGet("Indicador/{IdIndicador}")]
        public async Task<ActionResult<IEnumerable<IndicadorCheckListViewModel>>> GetDepartmentsbyParentId(long IdIndicador)
        {


            return await (from t1 in _context.Indicador
                          join t2 in _context.Indicador_CheckList
                              on t1.Id equals t2.IdIndicador
                          join t3 in _context.CheckList_Item
                              on t2.Id equals t3.IdIndicador_Checklist
                          join t4 in _context.CheckList
                              on t3.IdChecklist equals t4.Id
                         // where t1.Id = IdIndicador
                          group t4 by new {
                              IdIndicador = t1.Id, t2.Id,
                              t2.ItensChecar, t2.PontosPossiveis,
                              t4.Data
                          } into grouping
                          select new IndicadorCheckListViewModel
                          {
                              Id = grouping.Key.Id,
                              IdIndicador = grouping.Key.IdIndicador,
                              ItensChecar = grouping.Key.ItensChecar,
                              PontosPossiveis = grouping.Key.PontosPossiveis,
                              MaxDate = grouping.Max(item => item.Data)
                          }).Where(item => item.IdIndicador == IdIndicador).OrderByDescending(item => item.MaxDate).ToListAsync();

        }

        // PUT: api/Indicador_CheckList/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndicador_CheckList(int id, Indicador_CheckList indicador_CheckList)
        {
            if (id != indicador_CheckList.Id)
            {
                return BadRequest();
            }

            _context.Entry(indicador_CheckList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Indicador_CheckListExists(id))
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

        // POST: api/Indicador_CheckList
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Indicador_CheckList>> PostIndicador_CheckList(Indicador_CheckList indicador_CheckList)
        {
            _context.Indicador_CheckList.Add(indicador_CheckList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicador_CheckList", new { id = indicador_CheckList.Id }, indicador_CheckList);
        }

        // DELETE: api/Indicador_CheckList/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Indicador_CheckList>> DeleteIndicador_CheckList(int id)
        {
            var indicador_CheckList = await _context.Indicador_CheckList.FindAsync(id);
            if (indicador_CheckList == null)
            {
                return NotFound();
            }

            _context.Indicador_CheckList.Remove(indicador_CheckList);
            await _context.SaveChangesAsync();

            return indicador_CheckList;
        }

        private bool Indicador_CheckListExists(int id)
        {
            return _context.Indicador_CheckList.Any(e => e.Id == id);
        }
    }
}
