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
    }
}
