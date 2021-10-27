using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class EvidencijaContext : DbContext
    {
        public DbSet<Turnir> Turniri { get; set; }
        public DbSet<Disciplina> Discipline { get; set; }
        public DbSet<Ucesnik> Ucesnici { get; set; }

        public EvidencijaContext(DbContextOptions options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turnir>()
            .Property(t => t.Naziv)
            .IsRequired();

            modelBuilder.Entity<Turnir>()
            .Property(t => t.MaxDisciplina)
            .IsRequired();

            modelBuilder.Entity<Disciplina>()
            .Property(dsc => dsc.Naziv)
            .IsRequired();

            modelBuilder.Entity<Disciplina>()
            .Property(dsc => dsc.Naziv)
            .IsRequired();
            //     modelBuilder.Entity<Turnir>()
            //         .HasMany(t => t.Discipline)
            //         .WithOne(dsc => dsc.Turnir)
            //         .OnDelete(DeleteBehavior.Cascade);

            //     modelBuilder.Entity<Disciplina>()
            //     .HasMany(dsc => dsc.Ucesnici)
            //     .WithOne(uc => uc.Disciplina)
            //     .OnDelete(DeleteBehavior.Cascade);

            //     modelBuilder.Entity<Disciplina>()
            //         .HasOne<Turnir>(p => p.Turnir)
            //         .WithMany(t => t.Discipline)
            //         .HasForeignKey(p => p.TurnirID)
            //         .IsRequired(false)
            //         .OnDelete(DeleteBehavior.NoAction);

            //     modelBuilder.Entity<Ucesnik>()
            //         .HasOne<Disciplina>(p => p.Disciplina)
            //         .WithMany(dsc => dsc.Ucesnici)
            //         .HasForeignKey(p => p.DisciplinaID)
            //         .IsRequired(false)
            //         .OnDelete(DeleteBehavior.NoAction);

            //     modelBuilder.Entity<Ucesnik>()
            //         .HasOne<Turnir>(p => p.Turnir)
            //         .WithMany()
            //         .HasForeignKey(p => p.TurnirID)
            //         .IsRequired(false)
            //         .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}