using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class EvidencijaContext : DbContext
    {
        public DbSet<Fabrika> Fabrike { get; set; }
        public DbSet<Silos> Silosi { get; set; }

        public EvidencijaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Fabrika>()
            .HasMany(f => f.Silosi)
            .WithOne(s => s.Fabrika)
            .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(mb);
        }
    }
}