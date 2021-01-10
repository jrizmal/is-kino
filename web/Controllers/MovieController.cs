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
using web.Models.KinoViewModels;

namespace web.Controllers
{
    public class MovieController : Controller
    {
        private readonly KinoContext _context;

        public MovieController(KinoContext context)
        {
            _context = context;
        }


        // GET: Movie
        public async Task<IActionResult> Index(int? id, int? genreID, int? actorID, int? directorID)
        {
            var viewModel = new MovieIndexGenre();
            viewModel.Movies = await _context.movies                
                .Include(i => i.GenreMovies)
                    .ThenInclude(i => i.Genre)
                .Include(i => i.Actors)
                    .ThenInclude(i => i.People)
                .Include(i => i.Directors)
                    .ThenInclude(i => i.People)
                        
                .AsNoTracking()
                //.OrderBy(i => i.MovieID)
                .ToListAsync();

            if (id != null)
            {
                ViewData["MovieID"] = id.Value;
                Movie movie = viewModel.Movies.Where(
                    i => i.MovieID == id.Value).Single();
                // or GenreID?
                viewModel.Genres = movie.GenreMovies.Select(s => s.Genre);
                viewModel.Actors = movie.Actors.Select(s => s.People);
            }

            if (genreID != null)
            {
                ViewData["GenreID"] = genreID.Value;
                viewModel.GenreMovies = viewModel.Genres.Where(
                    x => x.GenreID == genreID).Single().GenreMovies;
            }

            if (actorID != null)
            {
                ViewData["ActorID"] = actorID.Value;
                viewModel.ActorConnect = viewModel.Actors.Where(
                    x => x.PeopleID == actorID).Single().Actors;
            }

            if (directorID != null)
            {
                ViewData["DirectorID"] = directorID.Value;
                viewModel.DirectorConnect = viewModel.Directors.Where(
                    x => x.PeopleID == directorID).Single().Directors;
            }

            return View(viewModel);
        }

        //GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var movie = await _context.movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("MovieID,Title,Rating,Length,StartDate,EndDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,Title,Rating,Length,StartDate,EndDate")] Movie movie)
        {
            if (id != movie.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieID))
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
            return View(movie);
        }

        // GET: Movie/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.movies.FindAsync(id);
            _context.movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.movies.Any(e => e.MovieID == id);
        }
    }
}
