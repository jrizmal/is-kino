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
            return View(await _context.seatShowing.ToListAsync());
        }

        // GET: SeatShowing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatShowing = await _context.seatShowing
                .FirstOrDefaultAsync(m => m.SeatShowingId == id);
            if (seatShowing == null)
            {
                return NotFound();
            }

            return View(seatShowing);
        }

        // GET: SeatShowing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeatShowing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeatShowingId,taken")] SeatShowing seatShowing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seatShowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(seatShowing);
        }

        // POST: SeatShowing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeatShowingId,taken")] SeatShowing seatShowing)
        {
            if (id != seatShowing.SeatShowingId)
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
                    if (!SeatShowingExists(seatShowing.SeatShowingId))
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
                .FirstOrDefaultAsync(m => m.SeatShowingId == id);
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
            return _context.seatShowing.Any(e => e.SeatShowingId == id);
        }
    }
}
