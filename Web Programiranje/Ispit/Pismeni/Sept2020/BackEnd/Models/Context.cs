using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Context : DbContext
    {
        public DbSet<Staniste> Stanista { get; set; }
        public DbSet<ZooVrt> ZooVrtovi { get; set; }

        public Context(DbContextOptions context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ZooVrt>()
            .HasMany(zv => zv.Stanista)
            .WithOne()
            .HasForeignKey(s => s.ZooVrtID)
            .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<ZooVrt>()
            .Property(zv => zv.TipoviStanista)
            .HasConversion(
                ts => string.Join(",", ts),
                ts => ts.Split(",", StringSplitOptions.RemoveEmptyEntries));

            mb.Entity<ZooVrt>()
            .Property(zv => zv.BojeStanista)
            .HasConversion(
                bs => string.Join(",", bs),
                bs => bs.Split(",", StringSplitOptions.RemoveEmptyEntries));

            base.OnModelCreating(mb);
        }
    }
}