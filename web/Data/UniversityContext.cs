using web.Models;
using Microsoft.EntityFrameworkCore;

namespace web.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {

        }

        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Student> students { get; set; }

        /* S tem lahko vplivaš na imena tabel */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}