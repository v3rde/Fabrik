using System.Data.Entity;

namespace Fabrik.Models
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
