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
    public class IndicadorCheckListViewModelsController : ControllerBase
    {
        private readonly VisioneContext _context;

        public IndicadorCheckListViewModelsController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/IndicadorCheckListViewModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndicadorCheckListViewModel>>> GetIndicadorCheckListViewModel()
        {
            return await _context.IndicadorCheckListViewModel.ToListAsync();
        }

        // GET: api/IndicadorCheckListViewModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IndicadorCheckListViewModel>> GetIndicadorCheckListViewModel(int id)
        {
            var indicadorCheckListViewModel = await _context.IndicadorCheckListViewModel.FindAsync(id);

            if (indicadorCheckListViewModel == null)
            {
                return NotFound();
            }

            return indicadorCheckListViewModel;
        }

        // GET: api/IndicadorCheckListViewModels/Indicador/5
        [HttpGet("Indicador/{IdIndicador}")]
        public async Task<ActionResult<IEnumerable<IndicadorCheckListViewModel>>> GetDepartmentsbyParentId(long IdIndicador)
        {
            return await _context.IndicadorCheckListViewModel.Where(item => item.IdIndicador == IdIndicador).ToListAsync();
        }

        // PUT: api/IndicadorCheckListViewModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndicadorCheckListViewModel(int id, IndicadorCheckListViewModel indicadorCheckListViewModel)
        {
            if (id != indicadorCheckListViewModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(indicadorCheckListViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndicadorCheckListViewModelExists(id))
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

        // POST: api/IndicadorCheckListViewModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<IndicadorCheckListViewModel>> PostIndicadorCheckListViewModel(IndicadorCheckListViewModel indicadorCheckListViewModel)
        {
            _context.IndicadorCheckListViewModel.Add(indicadorCheckListViewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndicadorCheckListViewModel", new { id = indicadorCheckListViewModel.Id }, indicadorCheckListViewModel);
        }

        // DELETE: api/IndicadorCheckListViewModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IndicadorCheckListViewModel>> DeleteIndicadorCheckListViewModel(int id)
        {
            var indicadorCheckListViewModel = await _context.IndicadorCheckListViewModel.FindAsync(id);
            if (indicadorCheckListViewModel == null)
            {
                return NotFound();
            }

            _context.IndicadorCheckListViewModel.Remove(indicadorCheckListViewModel);
            await _context.SaveChangesAsync();

            return indicadorCheckListViewModel;
        }

        private bool IndicadorCheckListViewModelExists(int id)
        {
            return _context.IndicadorCheckListViewModel.Any(e => e.Id == id);
        }
    }
}
