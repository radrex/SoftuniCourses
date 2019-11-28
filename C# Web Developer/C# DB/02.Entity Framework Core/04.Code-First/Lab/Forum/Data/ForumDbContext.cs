namespace Forum.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class ForumDbContext : DbContext
    {
        //-------------- Constructors ---------------
        public ForumDbContext()
        {

        }

        public ForumDbContext(DbContextOptions options) : base(options)
        {

        }

        //--------------- Properties ----------------
        public DbSet<User> Users { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostsTags { get; set; }

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
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Posts)
                        .WithOne(p => p.Category)
                        .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Post>()
                        .HasMany(p => p.Replies)
                        .WithOne(r => r.Post)
                        .HasForeignKey(r => r.PostId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Posts)
                        .WithOne(p => p.Author)
                        .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Replies)
                        .WithOne(r => r.Author)
                        .HasForeignKey(r => r.AuthorId);

            //modelBuilder.Entity<Reply>()
            //            .HasOne(r => r.Author)
            //            .WithMany(a => a.Replies)
            //            .HasForeignKey(r => r.AuthorId);

            //modelBuilder.Entity<Tag>()
            //            .ToTable("Tags");

            modelBuilder.Entity<PostTag>()
                        .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                        .HasOne(pt => pt.Post)
                        .WithMany(p => p.Tags)
                        .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                        .HasOne(pt => pt.Tag)
                        .WithMany(t => t.Posts)
                        .HasForeignKey(pt => pt.TagId);
        }
    }
}
