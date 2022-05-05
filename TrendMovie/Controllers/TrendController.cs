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

        // GET: api/Trend
        [HttpGet]
        public async Task<ActionResult<Response>> GetTrend()
        {


            var trend = await _context.Trend.Include(t => t.Movie).ToListAsync();

            var response = new Response();

            response.StatusCode = 404;
            response.StatusDescription = "Not Successful";

            if (trend != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Successful";
                response.TrendList = trend;
            }

            return response;
        }

        // GET: api/Trend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetTrend(int id)
        {
            var trend = await _context.Trend.Include(t => t.Movie).SingleOrDefaultAsync(t => t.TrendId == id);

            var response = new Response();

            response.StatusCode = 200;
            response.StatusDescription = "Successful";
            response.TrendList.Add(trend);

            if (trend == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Not Successful";
                
            }

            return response;
        }



        // PUT: api/Trend/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrend(int id, Trend trend)
        {
            var response = new Response();


            if (id != trend.TrendId)
            {

                response.StatusCode = 400;
                response.StatusDescription = "Not Successful";

                return Ok(response);
            }

            _context.Entry(trend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                response.StatusCode = 200;
                response.StatusDescription = "Successful";
                response.TrendList.Add(trend);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrendExists(id))
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


        // POST: api/Trend
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostTrend(Trend trend)
        {
            _context.Trend.Add(trend);
            await _context.SaveChangesAsync();

            var addTrend = CreatedAtAction("GetTrend", new { id = trend.TrendId }, trend);
            var response = new Response();
            response.StatusCode = 400;
            response.StatusDescription = "Not Successful";

            if (addTrend != null)
            {
                

                response.StatusCode = 200;
                response.StatusDescription = "Successful";
                response.TrendList.Add(trend);
            }

            return response;
        }

       

        private bool TrendExists(int id)
        {
            return _context.Trend.Any(e => e.TrendId == id);
        }
    }
}
