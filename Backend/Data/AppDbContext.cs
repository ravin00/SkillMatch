using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Employer)
                .WithMany()
                .HasForeignKey(j => j.EmployerId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Job)
                .WithMany()
                .HasForeignKey(m => m.JobId);
        }
    }
}