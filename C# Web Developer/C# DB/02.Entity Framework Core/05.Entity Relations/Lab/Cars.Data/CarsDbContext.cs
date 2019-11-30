namespace Cars.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Configurations;

    public class CarsDbContext : DbContext
    {
        //-------------- Constructors ---------------
        public CarsDbContext()
        {

        }

        public CarsDbContext(DbContextOptions options) : base(options)
        {

        }

        //--------------- Properties ----------------
        public DbSet<Make> Makes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<CarDealership> CarDealerships { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<LicensePlate> LicensePlates { get; set; }

        //---------------- Methods ------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new EngineConfiguration());
            modelBuilder.ApplyConfiguration(new CarDealershipConfiguration());
        }
    }
}
