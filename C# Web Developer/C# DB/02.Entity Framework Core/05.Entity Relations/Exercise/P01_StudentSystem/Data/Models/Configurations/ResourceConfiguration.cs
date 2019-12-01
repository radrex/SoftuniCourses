namespace P01_StudentSystem.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(r => r.ResourceId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(r => r.Course)
                   .WithMany(c => c.Resources)
                   .HasForeignKey(r => r.CourseId);

            //------------ PROPERTIES --------------
            builder.Property(r => r.Name)
                   .HasMaxLength(50)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.Property(r => r.Url)
                   .IsRequired(true)
                   .IsUnicode(false);

            builder.Property(r => r.ResourceType)
                   .IsRequired(true);
        }
    }
}
