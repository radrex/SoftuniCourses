namespace P01_StudentSystem.Data.Models
{
    using Enums;
    using System;

    public class Homework
    {
        //--------------- Properties ----------------
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }

        //-------- Student ------ [FK]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //-------- Course ------- [FK]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
