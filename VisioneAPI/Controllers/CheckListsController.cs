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
    public class CheckListsController : ControllerBase
    {
        private readonly VisioneContext _context;

        public CheckListsController(VisioneContext context)
        {
            _context = context;
        }

        // GET: api/CheckLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckList>>> GetCheckList()
        {
            return await _context.CheckList.ToListAsync();
        }

        // GET: api/CheckLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckList>> GetCheckList(int id)
        {
            var checkList = await _context.CheckList.FindAsync(id);

            if (checkList == null)
            {
                return NotFound();
            }

            return checkList;
        }

        // PUT: api/CheckLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckList(int id, CheckList checkList)
        {
            if (id != checkList.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckListExists(id))
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

        // POST: api/CheckLists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CheckList>> PostCheckList(CheckList checkList)
        {
            _context.CheckList.Add(checkList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckList", new { id = checkList.Id }, checkList);
        }

        // DELETE: api/CheckLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CheckList>> DeleteCheckList(int id)
        {
            var checkList = await _context.CheckList.FindAsync(id);
            if (checkList == null)
            {
                return NotFound();
            }

            _context.CheckList.Remove(checkList);
            await _context.SaveChangesAsync();

            return checkList;
        }

        private bool CheckListExists(int id)
        {
            return _context.CheckList.Any(e => e.Id == id);
        }
    }
}
