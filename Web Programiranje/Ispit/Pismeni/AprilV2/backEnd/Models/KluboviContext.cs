using Microsoft.EntityFrameworkCore;

namespace backEnd.Models
{
    public class KluboviContext :DbContext{
        public DbSet<Polica> Police{ get; set; }
        public DbSet<VideoKlub> VideoKlubovi{ get; set; }

        public KluboviContext(DbContextOptions options):base(options){}

        protected override void OnModelCreating(ModelBuilder mb){
            mb.Entity<VideoKlub>()
            .HasMany(vk => vk.Police)
            .WithOne()
            .HasForeignKey(p => p.VideoKlubID)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(mb);
        }
    }
}