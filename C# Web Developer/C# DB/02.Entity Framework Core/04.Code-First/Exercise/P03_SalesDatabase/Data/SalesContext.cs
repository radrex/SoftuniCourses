namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SalesContext : DbContext
    {
        //---------------- Constructors -----------------
        public SalesContext()
        {

        }
        public SalesContext(DbContextOptions options) : base(options)
        {

        }

        //----------------- Properties ------------------
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        //------------------ Methods --------------------
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
            ConfigureProductEntity(modelBuilder);
            ConfigureCustomerEntity(modelBuilder);
            ConfigureStoreEntity(modelBuilder);
            ConfigureSaleEntity(modelBuilder);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Product>()
                        .HasKey(p => p.ProductId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Product>()
                        .Property(p => p.Name)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Quantity)
                        .IsRequired(true);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .IsRequired(true);

            modelBuilder.Entity<Product>()  // For P04_ProductsMigration
                        .Property(p => p.Description)
                        .HasMaxLength(250)
                        .HasDefaultValue("No description")
                        .IsRequired(false);
        }

        private void ConfigureCustomerEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.CustomerId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Customer>()
                        .Property(c => c.Name)
                        .HasMaxLength(100)
                        .IsRequired(true)
                        .IsUnicode(true);

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Email)
                        .HasMaxLength(80)
                        .IsRequired(false)
                        .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Email)
                        .IsUnicode(false);
        }

        private void ConfigureStoreEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Store>()
                        .HasKey(s => s.StoreId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Store>()
                        .Property(s => s.Name)
                        .HasMaxLength(80)
                        .IsRequired(true)
                        .IsUnicode(true);
        }

        private void ConfigureSaleEntity(ModelBuilder modelBuilder)
        {
            //---------------- PRIMARY KEY ------------------
            modelBuilder.Entity<Sale>()
                        .HasKey(s => s.SaleId);

            //---------------- FOREIGN KEYS -----------------
            modelBuilder.Entity<Sale>()
                        .HasOne(s => s.Product)
                        .WithMany(p => p.Sales)
                        .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Sale>()
                        .HasOne(s => s.Customer)
                        .WithMany(c => c.Sales)
                        .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Sale>()
                        .HasOne(s => s.Store)
                        .WithMany(st => st.Sales)
                        .HasForeignKey(s => s.StoreId);

            //----------------- PROPERTIES ------------------
            modelBuilder.Entity<Sale>()
                        .Property(s => s.Date)
                        .HasColumnType("DATETIME2")
                        .IsRequired(true)
                        .HasDefaultValueSql("GETDATE()"); // For P05_SalesMigration
        }
    }
}
