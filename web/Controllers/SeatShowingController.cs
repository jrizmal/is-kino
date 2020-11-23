using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class SeatShowingController : Controller
    {
        private readonly KinoContext _context;

        public SeatShowingController(KinoContext context)
        {
            _context = context;
        }

        // GET: SeatShowing
        public async Task<IActionResult> Index()
        {
            var kinoContext = _context.seatShowing.Include(s => s.Seat).Include(s => s.Showing);
            return View(await kinoContext.ToListAsync());
        }

        // GET: SeatShowing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatShowing = await _context.seatShowing
                .Include(s => s.Seat)
                .Include(s => s.Showing)
                .FirstOrDefaultAsync(m => m.SeatShowingID == id);
            if (seatShowing == null)
            {
                return NotFound();
            }

            return View(seatShowing);
        }

        // GET: SeatShowing/Create
        public IActionResult Create()
        {
            ViewData["SeatID"] = new SelectList(_context.seats, "SeatID", "SeatID");
            ViewData["ShowingID"] = new SelectList(_context.showings, "ShowingID", "ShowingID");
            return View();
        }

        // POST: SeatShowing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeatShowingID,SeatID,ShowingID,Taken")] SeatShowing seatShowing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seatShowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeatID"] = new SelectList(_context.seats, "SeatID", "SeatID", seatShowing.SeatID);
            ViewData["ShowingID"] = new SelectList(_context.showings, "ShowingID", "ShowingID", seatShowing.ShowingID);
            return View(seatShowing);
        }

        // GET: SeatShowing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatShowing = await _context.seatShowing.FindAsync(id);
            if (seatShowing == null)
            {
                return NotFound();
            }
            ViewData["SeatID"] = new SelectList(_context.seats, "SeatID", "SeatID", seatShowing.SeatID);
            ViewData["ShowingID"] = new SelectList(_context.showings, "ShowingID", "ShowingID", seatShowing.ShowingID);
            return View(seatShowing);
        }

        // POST: SeatShowing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeatShowingID,SeatID,ShowingID,Taken")] SeatShowing seatShowing)
        {
            if (id != seatShowing.SeatShowingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seatShowing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatShowingExists(seatShowing.SeatShowingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeatID"] = new SelectList(_context.seats, "SeatID", "SeatID", seatShowing.SeatID);
            ViewData["ShowingID"] = new SelectList(_context.showings, "ShowingID", "ShowingID", seatShowing.ShowingID);
            return View(seatShowing);
        }

        // GET: SeatShowing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatShowing = await _context.seatShowing
                .Include(s => s.Seat)
                .Include(s => s.Showing)
                .FirstOrDefaultAsync(m => m.SeatShowingID == id);
            if (seatShowing == null)
            {
                return NotFound();
            }

            return View(seatShowing);
        }

        // POST: SeatShowing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seatShowing = await _context.seatShowing.FindAsync(id);
            _context.seatShowing.Remove(seatShowing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatShowingExists(int id)
        {
            return _context.seatShowing.Any(e => e.SeatShowingID == id);
        }
    }
}
