namespace Cinema.Data
{
    using System;
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public CinemaContext()  { }

        public CinemaContext(DbContextOptions options)
            : base(options)   { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProjectionEntity(modelBuilder);
            ConfigureTicketEntity(modelBuilder);
            ConfigureSeatEntity(modelBuilder);
        }

        private void ConfigureSeatEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seat>()
                        .HasOne(s => s.Hall)
                        .WithMany(h => h.Seats)
                        .HasForeignKey(s => s.HallId);
        }

        private void ConfigureProjectionEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projection>()
                        .HasOne(p => p.Hall)
                        .WithMany(h => h.Projections)
                        .HasForeignKey(p => p.HallId);

            modelBuilder.Entity<Projection>()
                        .HasOne(p => p.Movie)
                        .WithMany(m => m.Projections)
                        .HasForeignKey(p => p.MovieId);
        }

        private void ConfigureTicketEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                        .HasOne(t => t.Projection)
                        .WithMany(p => p.Tickets)
                        .HasForeignKey(t => t.ProjectionId);

            modelBuilder.Entity<Ticket>()
                        .HasOne(t => t.Customer)
                        .WithMany(c => c.Tickets)
                        .HasForeignKey(t => t.CustomerId);
        }
    }
}