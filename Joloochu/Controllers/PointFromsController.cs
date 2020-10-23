using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Joloochu;
using Joloochu.Data;

namespace Joloochu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointFromsController : ControllerBase
    {
        private readonly JoloochuContext _context;

        public PointFromsController(JoloochuContext context)
        {
            _context = context;
        }

        // GET: api/PointFroms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointFrom>>> GetPointFroms()
        {
            return await _context.PointFroms.ToListAsync();
        }

        // GET: api/PointFroms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PointFrom>> GetPointFrom(int id)
        {
            var pointFrom = await _context.PointFroms.FindAsync(id);

            if (pointFrom == null)
            {
                return NotFound();
            }

            return pointFrom;
        }

        // PUT: api/PointFroms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointFrom(int id, PointFrom pointFrom)
        {
            if (id != pointFrom.Id)
            {
                return BadRequest();
            }

            _context.Entry(pointFrom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointFromExists(id))
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

        // POST: api/PointFroms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PointFrom>> PostPointFrom(PointFrom pointFrom)
        {
            _context.PointFroms.Add(pointFrom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointFrom", new { id = pointFrom.Id }, pointFrom);
        }

        // DELETE: api/PointFroms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PointFrom>> DeletePointFrom(int id)
        {
            var pointFrom = await _context.PointFroms.FindAsync(id);
            if (pointFrom == null)
            {
                return NotFound();
            }

            _context.PointFroms.Remove(pointFrom);
            await _context.SaveChangesAsync();

            return pointFrom;
        }

        private bool PointFromExists(int id)
        {
            return _context.PointFroms.Any(e => e.Id == id);
        }
    }
}
