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
    public class TrendController : ControllerBase
    {
        private readonly TrendMovieDBContext _context;

        public TrendController(TrendMovieDBContext context)
        {
            _context = context;
        }

        //// GET: api/Trend
        //[HttpGet]
        //public async Task<ActionResult<Response>> GetTrend()
        //{


        //    var trend = await _context.Trend.ToListAsync();

        //    var response = new Response();

        //    response.StatusCode = 404;
        //    response.StatusDescription = "Not Successful";

        //    if (trend != null)
        //    {
        //        response.StatusCode = 200;
        //        response.StatusDescription = "Successful";
        //        response.Trend = trend;
        //    }

        //    return response;
        //}

        //// GET: api/Trend/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Trend>> GetTrend(int id)
        //{
        //    var trend = await _context.Trend.Include(t => t.Movie).SingleOrDefaultAsync(t => t.TrendId == id);

        //    if (trend == null)
        //    {
        //        return NotFound();
        //    }

        //    return trend;
        //}

        // GET: api/Trend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trend>>> GetTrend()
        {
            return await _context.Trend.ToListAsync();
        }



        // GET: api/Trend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trend>> GetTrend(int id)
        {
            var trend = await _context.Trend.FindAsync(id);

            if (trend == null)
            {
                return NotFound();
            }

            return trend;
        }

        // PUT: api/Trend/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrend(int id, Trend trend)
        {
            if (id != trend.TrendId)
            {
                return BadRequest();
            }

            _context.Entry(trend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trend
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trend>> PostTrend(Trend trend)
        {
            _context.Trend.Add(trend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrend", new { id = trend.TrendId }, trend);
        }

        // DELETE: api/Trend/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrend(int id)
        {
            var trend = await _context.Trend.FindAsync(id);
            if (trend == null)
            {
                return NotFound();
            }

            _context.Trend.Remove(trend);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool TrendExists(int id)
        {
            return _context.Trend.Any(e => e.TrendId == id);
        }
    }
}
