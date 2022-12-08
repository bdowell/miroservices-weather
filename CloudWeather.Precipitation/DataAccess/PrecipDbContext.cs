using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Precipitation.DataAccess
{
    public class PrecipDbContext : DbContext
    {
        public PrecipDbContext(){ }
        public PrecipDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Precipitaion> Precipitaion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Precipitaion>(b => { b.ToTable("precipitation"); });
        }
    }
}
