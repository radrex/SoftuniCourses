namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        //--------------- Properties ----------------
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        //-------- Resource ------ [FK]
        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();

        //-------- Homework ------ [FK]
        public ICollection<Homework> HomeworkSubmissions { get; set; } = new HashSet<Homework>();

        //---- StudentCourses --- [FK] -- Mapping Table --
        public ICollection<StudentCourse> StudentsEnrolled { get; set; } = new HashSet<StudentCourse>();
    }
}
