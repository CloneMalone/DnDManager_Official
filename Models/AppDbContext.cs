using Microsoft.EntityFrameworkCore;

namespace DnDManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            //Dbset properties 
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data goes here
        }
    }
}
