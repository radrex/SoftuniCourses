namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Configurations;

    public class PetStoreDbContext : DbContext
    {
        //------------------------ Constructors -------------------------
        public PetStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public PetStoreDbContext()
        {
        }

        //------------------------- Properties --------------------------
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<ToyOrder> ToyOrders { get; set; }

        //--------------------------- Methods ---------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BreedConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FoodOrderConfiguration());
            modelBuilder.ApplyConfiguration(new ToyOrderConfiguration());
        }
    }
}
