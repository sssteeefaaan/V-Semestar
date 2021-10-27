using Microsoft.EntityFrameworkCore;

namespace TreciCas.Models
{
    public class ZooContext : DbContext
    {
        public DbSet<Vrt> Vrtovi { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }

        public ZooContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vrt>()
                .HasMany(s => s.Lokacije)
                .WithOne(s => s.Vrt)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
