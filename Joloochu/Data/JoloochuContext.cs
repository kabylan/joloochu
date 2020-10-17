using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Joloochu;

namespace Joloochu.Data
{
    public class JoloochuContext : DbContext
    {
        public JoloochuContext (DbContextOptions<JoloochuContext> options)
            : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Joloochu.Ticket> Ticket { get; set; }
        public DbSet<Joloochu.Region> Regions { get; set; }
        public DbSet<Joloochu.District> Districts { get; set; }
        public DbSet<Joloochu.City> Cities { get; set; }
        public DbSet<Joloochu.Village> Villages { get; set; }
        public DbSet<Joloochu.Point> Points { get; set; }
    }
}
