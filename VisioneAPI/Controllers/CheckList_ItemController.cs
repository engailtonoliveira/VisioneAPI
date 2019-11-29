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
    public class CheckList_ItemController : ControllerBase
    {
        private readonly VisioneContext _context;

        public CheckList_ItemController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/CheckList_Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckList_Item>>> GetCheckList_Item()
        {
            return await _context.CheckList_Item.ToListAsync();
        }

        // GET: api/CheckList_Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckList_Item>> GetCheckList_Item(int id)
        {
            var checkList_Item = await _context.CheckList_Item.FindAsync(id);

            if (checkList_Item == null)
            {
                return NotFound();
            }

            return checkList_Item;
        }

        // PUT: api/CheckList_Item/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckList_Item(int id, CheckList_Item checkList_Item)
        {
            if (id != checkList_Item.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkList_Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckList_ItemExists(id))
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

        // POST: api/CheckList_Item
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CheckList_Item>> PostCheckList_Item(CheckList_Item checkList_Item)
        {
            _context.CheckList_Item.Add(checkList_Item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckList_Item", new { id = checkList_Item.Id }, checkList_Item);
        }

        // DELETE: api/CheckList_Item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CheckList_Item>> DeleteCheckList_Item(int id)
        {
            var checkList_Item = await _context.CheckList_Item.FindAsync(id);
            if (checkList_Item == null)
            {
                return NotFound();
            }

            _context.CheckList_Item.Remove(checkList_Item);
            await _context.SaveChangesAsync();

            return checkList_Item;
        }

        private bool CheckList_ItemExists(int id)
        {
            return _context.CheckList_Item.Any(e => e.Id == id);
        }
    }
}
