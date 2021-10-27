using Microsoft.EntityFrameworkCore;

namespace WebAPIOData.Models
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>().HasOne(s => s.ToAirportRef); //.WithMany(s => s.Rute);
            modelBuilder.Entity<Route>().HasOne(s => s.FromAirportRef); //.WithMany(s => s.Rute);
        }
    }
}
