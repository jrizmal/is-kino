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
    public class DirectorsController : Controller
    {
        private readonly KinoContext _context;

        public DirectorsController(KinoContext context)
        {
            _context = context;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            var kinoContext = _context.Directors.Include(d => d.Movie).Include(d => d.People);
            return View(await kinoContext.ToListAsync());
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors
                .Include(d => d.Movie)
                .Include(d => d.People)
                .FirstOrDefaultAsync(m => m.DirectorsID == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title");
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "Name");
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectorsID,MovieID,PeopleID")] Directors directors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title", directors.MovieID);
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "Name", directors.PeopleID);
            return View(directors);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors.FindAsync(id);
            if (directors == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title", directors.MovieID);
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "Name", directors.PeopleID);
            return View(directors);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectorsID,MovieID,PeopleID")] Directors directors)
        {
            if (id != directors.DirectorsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorsExists(directors.DirectorsID))
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
            ViewData["MovieID"] = new SelectList(_context.movies, "MovieID", "Title", directors.MovieID);
            ViewData["PeopleID"] = new SelectList(_context.people, "PeopleID", "Name", directors.PeopleID);
            return View(directors);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors
                .Include(d => d.Movie)
                .Include(d => d.People)
                .FirstOrDefaultAsync(m => m.DirectorsID == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directors = await _context.Directors.FindAsync(id);
            _context.Directors.Remove(directors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorsExists(int id)
        {
            return _context.Directors.Any(e => e.DirectorsID == id);
        }
    }
}
