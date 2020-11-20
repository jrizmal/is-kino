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
    public class ShowingController : Controller
    {
        private readonly KinoContext _context;

        public ShowingController(KinoContext context)
        {
            _context = context;
        }

        // GET: Showing
        public async Task<IActionResult> Index()
        {
            var kinoContext = _context.showings.Include(s => s.Movie).Include(s => s.Room);
            return View(await kinoContext.ToListAsync());
        }

        // GET: Showing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.showings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowingId == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // GET: Showing/Create
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieId", "MovieId");
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: Showing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowingId,MovieID,RoomID,StartTime")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieId", "MovieId", showing.MovieID);
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "RoomId", showing.RoomID);
            return View(showing);
        }

        // GET: Showing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.showings.FindAsync(id);
            if (showing == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieId", "MovieId", showing.MovieID);
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "RoomId", showing.RoomID);
            return View(showing);
        }

        // POST: Showing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowingId,MovieID,RoomID,StartTime")] Showing showing)
        {
            if (id != showing.ShowingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowingExists(showing.ShowingId))
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
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieId", "MovieId", showing.MovieID);
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "RoomId", showing.RoomID);
            return View(showing);
        }

        // GET: Showing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.showings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowingId == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // POST: Showing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showing = await _context.showings.FindAsync(id);
            _context.showings.Remove(showing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowingExists(int id)
        {
            return _context.showings.Any(e => e.ShowingId == id);
        }
    }
}
