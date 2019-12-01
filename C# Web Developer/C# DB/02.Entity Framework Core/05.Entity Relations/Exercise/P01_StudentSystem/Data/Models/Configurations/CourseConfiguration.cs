namespace P01_StudentSystem.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(c => c.CourseId);

            //------------ PROPERTIES --------------
            builder.Property(c => c.Name)
                   .HasMaxLength(80)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.Property(c => c.Description)
                   .IsRequired(false)
                   .IsUnicode(true);

            builder.Property(c => c.StartDate)
                   .HasColumnType("DATETIME2")
                   .IsRequired(true);

            builder.Property(c => c.EndDate)
                   .HasColumnType("DATETIME2")
                   .IsRequired(true);

            builder.Property(c => c.Price)
                   .IsRequired(true);
        }
    }
}
