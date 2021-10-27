using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class Context : DbContext
    {
        public DbSet<Igrac> Igraci { get; set; }
        public DbSet<Mec> Mecevi { get; set; }
        public DbSet<Poen> Poeni { get; set; }
        public Context(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Mec>()
            .HasMany(m => m.Igraci)
            .WithOne()
            .HasForeignKey(i => i.MecID)
            .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Igrac>()
            .HasMany(i => i.Poeni)
            .WithOne()
            .HasForeignKey(p => p.IgracID)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(mb);
        }
    }
}