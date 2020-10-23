using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Joloochu;
using Joloochu.Data;
using System.Security.Cryptography.X509Certificates;

namespace Joloochu.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly JoloochuContext _context;

        public TicketsController(JoloochuContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("[action]/{fromid}/{toid}")]
        public IEnumerable<Ticket> GetTickets(int? fromid, int? toid)
        {
            IEnumerable<Ticket> tickets = _context.Ticket
                .Where(p => p.PointToId == toid & p.PointFromId == fromid)
                .ToList();

            return tickets;
        }

        //[HttpGet]
        //[Route("[action]")]
        //public IEnumerable<Ticket> FindTicketsByPointFrom(PointFrom from)
        //{

        //    IEnumerable<Ticket> tickets = _context.Ticket
        //        .Include(p => p.PointFrom)
        //        .ToList();

        //    tickets = tickets.Where(
        //        p => p.PointFrom.CityId == from.CityId &
        //        p.PointFrom.DistrictId == from.DistrictId &
        //        p.PointFrom.RegionId == from.RegionId &
        //        p.PointFrom.VillageId == from.VillageId
        //    );

        //    return tickets.ToList();
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public IEnumerable<Ticket> FindTicketsByPointTo(PointTo to)
        //{

        //    IEnumerable<Ticket> tickets = _context.Ticket
        //        .Include(p => p.PointTo)
        //        .ToList();

        //    tickets = tickets.Where(
        //        p => p.PointTo.CityId == to.CityId &
        //        p.PointTo.DistrictId == to.DistrictId &
        //        p.PointTo.RegionId == to.RegionId &
        //        p.PointTo.VillageId == to.VillageId
        //    );

        //    return tickets.ToList();
        //}



        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return await _context.Ticket.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.id)
            {
                return BadRequest();
            }

            //// update point
            //_context.Points.Update(ticket.From);
            //_context.Points.Update(ticket.To);

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            // get point and add

            //Point from = ticket.From;
            //Point to = ticket.To;

            //_context.Points.Add(ticket.From);
            //_context.Points.Add(ticket.To);

            //ticket.FromId = from.Id;
            //ticket.ToId = to.Id;

            //// id of point

            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.id == id);
        }
    }
}
