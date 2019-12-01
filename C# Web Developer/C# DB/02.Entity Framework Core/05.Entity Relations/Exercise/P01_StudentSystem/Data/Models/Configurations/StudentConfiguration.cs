namespace P01_StudentSystem.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(s => s.StudentId);

            //------------ PROPERTIES --------------
            builder.Property(s => s.Name)
                   .HasMaxLength(100)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.Property(s => s.PhoneNumber)
                   .HasMaxLength(10)
                   .IsFixedLength(true)
                   .IsRequired(false)
                   .IsUnicode(false);

            builder.Property(s => s.RegisteredOn)
                   .HasColumnType("DATETIME2")
                   .IsRequired(true);

            builder.Property(s => s.Birthday)
                   .HasColumnType("DATETIME2")
                   .IsRequired(false);
        }
    }
}
