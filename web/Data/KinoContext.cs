using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using web.Models;   // za AppUser

namespace web.Data
{
    public class KinoContext : IdentityDbContext<AppUser>
    {
        public KinoContext(DbContextOptions<KinoContext> options) : base(options)
        {

        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Seat> seats { get; set; }
        public DbSet<Showing> showings { get; set; }
        public DbSet<SeatShowing> seatShowing { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<People> people { get; set; }


        /* S tem lahko vplivaš na imena tabel */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Seat>().ToTable("Seat");
            modelBuilder.Entity<Showing>().ToTable("Showing");
            modelBuilder.Entity<SeatShowing>().ToTable("SeatShowing");
        }


        /* S tem lahko vplivaš na imena tabel */
        public DbSet<web.Models.GenreMovie> GenreMovie { get; set; }


        /* S tem lahko vplivaš na imena tabel */
        public DbSet<web.Models.Directors> Directors { get; set; }


        /* S tem lahko vplivaš na imena tabel */
        public DbSet<web.Models.Actors> Actors { get; set; }
    }
}