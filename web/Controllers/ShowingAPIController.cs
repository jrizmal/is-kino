using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    [Route("api/showing")]
    [ApiController]
    public class ShowingAPIController : ControllerBase
    {
        private readonly KinoContext _context;

        public ShowingAPIController(KinoContext context)
        {
            _context = context;
        }

        // GET: api/ShowingAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Showing>>> Getshowings()
        {
            return await _context.showings.ToListAsync();
        }

        // GET: api/ShowingAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Showing>> GetShowing(int id)
        {
            var showing = await _context.showings.Where(sh=>sh.MovieID==id).OrderBy(sh=>sh.StartTime).ToArrayAsync();

            if (showing == null)
            {
                return NotFound();
            }

            return Ok(showing);
        }

        // PUT: api/ShowingAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowing(int id, Showing showing)
        {
            if (id != showing.ShowingID)
            {
                return BadRequest();
            }

            _context.Entry(showing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowingExists(id))
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

        // POST: api/ShowingAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Showing>> PostShowing(Showing showing)
        {
            _context.showings.Add(showing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShowing", new { id = showing.ShowingID }, showing);
        }

        // DELETE: api/ShowingAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Showing>> DeleteShowing(int id)
        {
            var showing = await _context.showings.FindAsync(id);
            if (showing == null)
            {
                return NotFound();
            }

            _context.showings.Remove(showing);
            await _context.SaveChangesAsync();

            return showing;
        }

        private bool ShowingExists(int id)
        {
            return _context.showings.Any(e => e.ShowingID == id);
        }
    }
}
