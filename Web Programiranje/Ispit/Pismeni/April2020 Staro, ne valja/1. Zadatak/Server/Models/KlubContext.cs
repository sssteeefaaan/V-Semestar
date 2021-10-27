using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class KlubContext : DbContext
    {
        public DbSet<VideoKlub> VideoKlubovi { get; set; }
        public DbSet<Polica> Police { get; set; }

        public KlubContext(DbContextOptions options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoKlub>()
            .HasMany(s => s.Police)
            .WithOne(s => s.VideoKlub)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Polica>()
                .HasKey(c => new { c.Oznaka, c.VideoKlubID });

            base.OnModelCreating(modelBuilder);
        }
    }
}