using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace TP4.Services
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Movies> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            var movies = _context.movies
                .Where(m => m.Genres.GenreName == userDefinedGenre)
                .ToList();

            return movies;
        }
        public List<Movies> ListMovies()
        {
            var movies= _context.movies
                .OrderBy(m => m.Name)
                .ToList();
            return movies;
        }

    }
}
