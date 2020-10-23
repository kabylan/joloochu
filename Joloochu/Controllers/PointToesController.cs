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
    public class PointToesController : ControllerBase
    {
        private readonly JoloochuContext _context;

        public PointToesController(JoloochuContext context)
        {
            _context = context;
        }

        // GET: api/PointToes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointTo>>> GetPointTos()
        {
            return await _context.PointTos.ToListAsync();
        }

        // GET: api/PointToes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PointTo>> GetPointTo(int id)
        {
            var pointTo = await _context.PointTos.FindAsync(id);

            if (pointTo == null)
            {
                return NotFound();
            }

            return pointTo;
        }

        // PUT: api/PointToes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointTo(int id, PointTo pointTo)
        {
            if (id != pointTo.Id)
            {
                return BadRequest();
            }

            _context.Entry(pointTo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointToExists(id))
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

        // POST: api/PointToes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PointTo>> PostPointTo(PointTo pointTo)
        {
            _context.PointTos.Add(pointTo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointTo", new { id = pointTo.Id }, pointTo);
        }

        // DELETE: api/PointToes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PointTo>> DeletePointTo(int id)
        {
            var pointTo = await _context.PointTos.FindAsync(id);
            if (pointTo == null)
            {
                return NotFound();
            }

            _context.PointTos.Remove(pointTo);
            await _context.SaveChangesAsync();

            return pointTo;
        }

        private bool PointToExists(int id)
        {
            return _context.PointTos.Any(e => e.Id == id);
        }
    }
}
