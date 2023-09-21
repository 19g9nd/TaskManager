using Microsoft.EntityFrameworkCore;

namespace TaskManager
{
    public class TaskDbContext : DbContext
    {
        public DbSet<ProcessInfo> Processes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Server=localhost;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);

        }

    }
}
