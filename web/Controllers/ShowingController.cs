using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;

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
            var showings = from s in _context.showings 
                            select s;
            showings = showings.OrderBy(s => s.StartTime);
            showings = showings.Include(s => s.Movie).Include(s => s.Room);

            return View(await showings.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.ShowingID == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // GET: Showing/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title");
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "Name");
            return View();
        }

        // POST: Showing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ShowingID,MovieID,RoomID,StartTime")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showing);
                await _context.SaveChangesAsync();

                /* Dodaj še vse sedeže */
                

                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title", showing.MovieID);
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "Name", showing.RoomID);
            return View(showing);
        }

        // GET: Showing/Edit/5
        [Authorize(Roles = "Administrator")]
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
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title", showing.MovieID);
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "Name", showing.RoomID);
            return View(showing);
        }

        // POST: Showing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ShowingID,MovieID,RoomID,StartTime")] Showing showing)
        {
            if (id != showing.ShowingID)
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
                    if (!ShowingExists(showing.ShowingID))
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
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title", showing.MovieID);
            ViewData["RoomID"] = new SelectList(_context.rooms, "RoomId", "Name", showing.RoomID);
            return View(showing);
        }

        // GET: Showing/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.showings
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowingID == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // POST: Showing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showing = await _context.showings.FindAsync(id);
            _context.showings.Remove(showing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowingExists(int id)
        {
            return _context.showings.Any(e => e.ShowingID == id);
        }
    }
}
