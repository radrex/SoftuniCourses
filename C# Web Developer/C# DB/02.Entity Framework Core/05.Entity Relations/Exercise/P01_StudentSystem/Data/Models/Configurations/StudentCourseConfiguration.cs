namespace P01_StudentSystem.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            //------------ PRIMARY KEY [ COMPOSITE KEY ] -------------
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            //------------ FOREIGN KEYS ------------
            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.CourseEnrollments)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentsEnrolled)
                   .HasForeignKey(sc => sc.CourseId);
        }
    }
}
