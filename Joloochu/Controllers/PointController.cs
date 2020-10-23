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
    public class PointController : ControllerBase
    {
        private readonly JoloochuContext _context;

        public PointController(JoloochuContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Region> GetPointDic()
        {
            return _context.Regions
                .Include(p => p.Cities)
                .Include(p => p.Districts)
                .ThenInclude(p => p.Villages)
                .ToList();
        }
    }
}
