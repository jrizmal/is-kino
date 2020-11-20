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
    public class GenreMovieController : Controller
    {
        private readonly KinoContext _context;

        public GenreMovieController(KinoContext context)
        {
            _context = context;
        }

        // GET: GenreMovie
        public async Task<IActionResult> Index()
        {
            var kinoContext = _context.GenreMovie.Include(g => g.Genre).Include(g => g.Movie);
            return View(await kinoContext.ToListAsync());
        }

        // GET: GenreMovie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovie = await _context.GenreMovie
                .Include(g => g.Genre)
                .Include(g => g.Movie)
                .FirstOrDefaultAsync(m => m.GenreMovieID == id);
            if (genreMovie == null)
            {
                return NotFound();
            }

            return View(genreMovie);
        }

        // GET: GenreMovie/Create
        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_context.genres, "GenreID", "GenreID");
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId");
            return View();
        }

        // POST: GenreMovie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreMovieID,MovieId,GenreID")] GenreMovie genreMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genreMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreID"] = new SelectList(_context.genres, "GenreID", "GenreID", genreMovie.GenreID);
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId", genreMovie.MovieId);
            return View(genreMovie);
        }

        // GET: GenreMovie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovie = await _context.GenreMovie.FindAsync(id);
            if (genreMovie == null)
            {
                return NotFound();
            }
            ViewData["GenreID"] = new SelectList(_context.genres, "GenreID", "GenreID", genreMovie.GenreID);
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId", genreMovie.MovieId);
            return View(genreMovie);
        }

        // POST: GenreMovie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreMovieID,MovieId,GenreID")] GenreMovie genreMovie)
        {
            if (id != genreMovie.GenreMovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreMovieExists(genreMovie.GenreMovieID))
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
            ViewData["GenreID"] = new SelectList(_context.genres, "GenreID", "GenreID", genreMovie.GenreID);
            ViewData["MovieId"] = new SelectList(_context.movies, "MovieId", "MovieId", genreMovie.MovieId);
            return View(genreMovie);
        }

        // GET: GenreMovie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovie = await _context.GenreMovie
                .Include(g => g.Genre)
                .Include(g => g.Movie)
                .FirstOrDefaultAsync(m => m.GenreMovieID == id);
            if (genreMovie == null)
            {
                return NotFound();
            }

            return View(genreMovie);
        }

        // POST: GenreMovie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreMovie = await _context.GenreMovie.FindAsync(id);
            _context.GenreMovie.Remove(genreMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreMovieExists(int id)
        {
            return _context.GenreMovie.Any(e => e.GenreMovieID == id);
        }
    }
}
