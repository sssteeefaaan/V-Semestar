using Microsoft.EntityFrameworkCore;

namespace Primer1.Models
{
    public class ZooContext : DbContext // dotnet add package Microsoft.EntityFrameworkCore
    {
        #region Property
        public DbSet<Vrt> Vrtovi { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        #endregion

        #region Constructors
        public ZooContext(DbContextOptions options)
        : base(options) { }
        #endregion
    }
}