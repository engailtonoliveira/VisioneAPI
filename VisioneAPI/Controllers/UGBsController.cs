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
    public class UGBsController : ControllerBase
    {
        private readonly VisioneContext _context;

        public UGBsController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/UGBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UGB>>> GetUGB()
        {
            return await _context.UGB.ToListAsync();
        }

        // GET: api/UGBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UGB>> GetUGB(int id)
        {
            var uGB = await _context.UGB.FindAsync(id);

            if (uGB == null)
            {
                return NotFound();
            }

            return uGB;
        }

        // GET: api/UGBs/lider/5
        [HttpGet("lider/{liderId}")]
        public async Task<ActionResult<IEnumerable<UGB>>> GetDepartmentsbyParentId(long liderId)
        {
            return await _context.UGB.Where(ugb => ugb.IdGestor == liderId).ToListAsync();
        }

        // PUT: api/UGBs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUGB(int id, UGB uGB)
        {
            if (id != uGB.Id)
            {
                return BadRequest();
            }

            _context.Entry(uGB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UGBExists(id))
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

        // POST: api/UGBs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UGB>> PostUGB(UGB uGB)
        {
            _context.UGB.Add(uGB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUGB", new { id = uGB.Id }, uGB);
        }

        // DELETE: api/UGBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UGB>> DeleteUGB(int id)
        {
            var uGB = await _context.UGB.FindAsync(id);
            if (uGB == null)
            {
                return NotFound();
            }

            _context.UGB.Remove(uGB);
            await _context.SaveChangesAsync();

            return uGB;
        }

        private bool UGBExists(int id)
        {
            return _context.UGB.Any(e => e.Id == id);
        }
    }
}
