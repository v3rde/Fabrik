using Fabrik.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrik
{
    public class FabrikDb : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Production> Productions { get; set; }
    }
}
