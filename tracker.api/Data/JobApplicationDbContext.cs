// ********************************
// Sqlite datastore
// ********************************
using Microsoft.EntityFrameworkCore;

namespace tracker.api.Data
{
    public class JobApplicationDbContext : DbContext
    {
        public JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<JobApplicationEntity> JobApplications => Set<JobApplicationEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For simplicity I am going to hard code the path/db name rather than have them as
            // configuration items with DI IConfiguration.
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "JobApplicationTracker.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.Seed(modelBuilder);
        }
    }
}