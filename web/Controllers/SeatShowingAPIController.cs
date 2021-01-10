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
    [Route("api/seatshowing")]
    [ApiController]
    public class SeatShowingAPIController : ControllerBase
    {
        private readonly KinoContext _context;

        public SeatShowingAPIController(KinoContext context)
        {
            _context = context;
        }

        // GET: api/SeatShowingAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatShowing>>> GetseatShowing()
        {
            return await _context.seatShowing.ToListAsync();
        }

        // GET: api/SeatShowingAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatShowing>> GetSeatShowing(int id)
        {
            var seatShowing = await _context.seatShowing.FindAsync(id);

            if (seatShowing == null)
            {
                return NotFound();
            }

            return seatShowing;
        }

        [HttpGet("showing/{id}")]
        public async Task<ActionResult<SeatShowing>> GetSeatShowingByShowing(int id)
        {
            var seatShowing = await _context.seatShowing.Where(ss=>ss.Showing.ShowingID==id).ToListAsync();

            if (seatShowing == null)
            {
                return NotFound();
            }

            return Ok(seatShowing);
        }

        // PUT: api/SeatShowingAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatShowing(int id, SeatShowing seatShowing)
        {
            if (id != seatShowing.SeatShowingID)
            {
                return BadRequest();
            }

            _context.Entry(seatShowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatShowingExists(id))
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

        // POST: api/SeatShowingAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SeatShowing>> PostSeatShowing(SeatShowing seatShowing)
        {
            _context.seatShowing.Add(seatShowing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatShowing", new { id = seatShowing.SeatShowingID }, seatShowing);
        }

        // DELETE: api/SeatShowingAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeatShowing>> DeleteSeatShowing(int id)
        {
            var seatShowing = await _context.seatShowing.FindAsync(id);
            if (seatShowing == null)
            {
                return NotFound();
            }

            _context.seatShowing.Remove(seatShowing);
            await _context.SaveChangesAsync();

            return seatShowing;
        }

        private bool SeatShowingExists(int id)
        {
            return _context.seatShowing.Any(e => e.SeatShowingID == id);
        }
    }
}
