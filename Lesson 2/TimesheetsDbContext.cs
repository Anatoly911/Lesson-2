using Lesson_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson_2
{
    public class TimesheetsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=vma-postgres;Database=vma;Username=vma;Password=K8YEW7nZHkX2+cvF; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public TimesheetsDbContext(DbContextOptions<TimesheetsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
