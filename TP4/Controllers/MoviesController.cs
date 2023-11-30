using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Models;
using TP4.Services;

namespace TP3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        private readonly ApplicationDbContext _context;

        public MoviesController(MovieService movieService, ApplicationDbContext context)
        {
            _movieService = movieService;
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var orderedMovies = _movieService.ListMovies();
            return View(orderedMovies);
        }

        

        public IActionResult Create()
        {
            ViewData["Genresid"] = new SelectList(_context.Genres, "Id", "Id");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Genresid,date,ImageURL,formFile")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Genresid"] = new SelectList(_context.Genres, "Id", "Id", movies.Genresid);
            return View(movies);
        }
    }
}
