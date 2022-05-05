#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrendMovie.Models;

namespace TrendMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly TrendMovieDBContext _context;

        public MovieController(TrendMovieDBContext context)
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            var movies = await _context.Movie.ToListAsync();
            var response = new MovieResponse();
            response.StatusCode = 404;
            response.StatusDescription = "Not Successful";

            if (movies != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Successful";
                response.MovieList = movies;
            }

            return Ok(response);
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {

            var response = new MovieResponse();
            var movie = await _context.Movie.FindAsync(id);
            response.StatusCode = 200;
            response.StatusDescription = "Successful";
            response.MovieList.Add(movie);

            if (movie == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Not Successful";
                return Ok(response);
            }

            return Ok(response);
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            var response = new MovieResponse();

            if (id != movie.MovieId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Not Successful";
                return Ok(response);
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                response.StatusCode = 200;
                response.StatusDescription = "Successful";
                response.MovieList.Add(movie);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "Not Successful";

                    return Ok(response);

                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "Not Successful";
                    throw;
                }
            }

            return Ok(response);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }
    }
}
