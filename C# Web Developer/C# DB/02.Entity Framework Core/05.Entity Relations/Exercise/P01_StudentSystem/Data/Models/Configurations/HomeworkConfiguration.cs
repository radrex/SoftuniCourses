namespace P01_StudentSystem.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(h => h.HomeworkId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(h => h.Student)
                   .WithMany(s => s.HomeworkSubmissions)
                   .HasForeignKey(h => h.StudentId);

            builder.HasOne(h => h.Course)
                   .WithMany(c => c.HomeworkSubmissions)
                   .HasForeignKey(h => h.CourseId);

            //------------ PROPERTIES --------------
            builder.Property(h => h.Content)
                   .IsRequired(true)
                   .IsUnicode(false);

            builder.Property(h => h.ContentType)
                   .IsRequired(true);

            builder.Property(h => h.SubmissionTime)
                   .HasColumnType("DATETIME2")
                   .IsRequired(true);
        }
    }
}
