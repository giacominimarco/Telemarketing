using Microsoft.EntityFrameworkCore;

namespace Telemarketing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Indicator> Indicators { get; set; }
        public DbSet<Entities.Collect> Collects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Indicator>();
            modelBuilder.Entity<Entities.Collect>();
        }
    }
}
