using Lesson_2.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lesson_2.Db
{
    internal sealed class PersonDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.72;Database=GeekBrains;Username=postgres;Password=qwe123; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Ignore(x => x.Comment);
        }
    }
}
