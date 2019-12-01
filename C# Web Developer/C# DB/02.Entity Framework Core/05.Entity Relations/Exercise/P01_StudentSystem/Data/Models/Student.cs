namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        //--------------- Properties ----------------
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        //-------- Student ------ [FK]
        public ICollection<Homework> HomeworkSubmissions { get; set; } = new HashSet<Homework>();

        //---- StudentCourses --- [FK] -- Mapping Table --
        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new HashSet<StudentCourse>();
    }
}
