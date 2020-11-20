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
    public class ActorsController : Controller
    {
        private readonly KinoContext _context;

        public ActorsController(KinoContext context)
        {
            _context = context;
        }

        // GET: Actors
        public async Task<IActionResult> Index()
        {
            var kinoContext = _context.Actors.Include(a => a.Movie).Include(a => a.People);
            return View(await kinoContext.ToListAsync());
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actors
                .Include(a => a.Movie)
                .Include(a => a.People)
                .FirstOrDefaultAsync(m => m.ActorsID == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId");
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "PeopleID");
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorsID,MovieId,PeopleID")] Actors actors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId", actors.MovieId);
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "PeopleID", actors.PeopleID);
            return View(actors);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actors.FindAsync(id);
            if (actors == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId", actors.MovieId);
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "PeopleID", actors.PeopleID);
            return View(actors);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorsID,MovieId,PeopleID")] Actors actors)
        {
            if (id != actors.ActorsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorsExists(actors.ActorsID))
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
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId", actors.MovieId);
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "PeopleID", actors.PeopleID);
            return View(actors);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actors
                .Include(a => a.Movie)
                .Include(a => a.People)
                .FirstOrDefaultAsync(m => m.ActorsID == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actors = await _context.Actors.FindAsync(id);
            _context.Actors.Remove(actors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorsExists(int id)
        {
            return _context.Actors.Any(e => e.ActorsID == id);
        }
    }
}
