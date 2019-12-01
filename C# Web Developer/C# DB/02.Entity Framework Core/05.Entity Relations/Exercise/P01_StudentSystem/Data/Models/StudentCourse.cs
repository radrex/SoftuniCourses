namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        //--------------- Properties ----------------
        //-------- Student ------ [FK]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //-------- Course ------- [FK]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
