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
    public class UGBIndicadoresViewsController : ControllerBase
    {
        private readonly VisioneContext _context;

        public UGBIndicadoresViewsController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/UGBIndicadoresViews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UGBIndicadoresView>>> GetUGBIndicadoresView()
        {
            return await _context.UGBIndicadoresView.ToListAsync();
        }

        // GET: api/UGBIndicadoresViews/UGB/5
        [HttpGet("UGB/{IdUGB}")]
        public async Task<ActionResult<IEnumerable<UGBIndicadoresView>>> GetDepartmentsbyParentId(long IdUGB)
        {
            return await _context.UGBIndicadoresView.Where(ugbIndicadores => ugbIndicadores.UGBId == IdUGB).ToListAsync();
        }

        // GET: api/UGBIndicadoresViews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UGBIndicadoresView>> GetUGBIndicadoresView(int id)
        {
            var uGBIndicadoresView = await _context.UGBIndicadoresView.FindAsync(id);

            if (uGBIndicadoresView == null)
            {
                return NotFound();
            }

            return uGBIndicadoresView;
        }

        // PUT: api/UGBIndicadoresViews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUGBIndicadoresView(int id, UGBIndicadoresView uGBIndicadoresView)
        {
            if (id != uGBIndicadoresView.Id)
            {
                return BadRequest();
            }

            _context.Entry(uGBIndicadoresView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UGBIndicadoresViewExists(id))
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

        // POST: api/UGBIndicadoresViews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UGBIndicadoresView>> PostUGBIndicadoresView(UGBIndicadoresView uGBIndicadoresView)
        {
            _context.UGBIndicadoresView.Add(uGBIndicadoresView);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUGBIndicadoresView", new { id = uGBIndicadoresView.Id }, uGBIndicadoresView);
        }

        // DELETE: api/UGBIndicadoresViews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UGBIndicadoresView>> DeleteUGBIndicadoresView(int id)
        {
            var uGBIndicadoresView = await _context.UGBIndicadoresView.FindAsync(id);
            if (uGBIndicadoresView == null)
            {
                return NotFound();
            }

            _context.UGBIndicadoresView.Remove(uGBIndicadoresView);
            await _context.SaveChangesAsync();

            return uGBIndicadoresView;
        }

        private bool UGBIndicadoresViewExists(int id)
        {
            return _context.UGBIndicadoresView.Any(e => e.Id == id);
        }
    }
}
