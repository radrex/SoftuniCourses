namespace P01_StudentSystem
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using StudentSystemContext context = new StudentSystemContext();
            context.Database.Migrate();
            Seed(context);
        }

        private static void Seed(StudentSystemContext context)
        {
            Student[] students = new[]
            {
                new Student { Name = "Ivan", RegisteredOn = new DateTime(2019, 8, 10) },
                new Student { Name = "Georgi", RegisteredOn = new DateTime(2018, 10, 10) },
                new Student { Name = "Ana", RegisteredOn = new DateTime(2019, 2, 17) },
                new Student { Name = "Mariya", RegisteredOn = new DateTime(2019, 1, 9) },
                new Student { Name = "Stoyan", RegisteredOn = new DateTime(2019, 9, 24) },
            };
            context.Students.AddRange(students);

            Course[] courses = new[]
            {
                new Course {Name = "C# Basics", StartDate = new DateTime(2019, 1, 10), EndDate = new DateTime(2019, 3, 10), Price = 120.0M},
                new Course {Name = "C# Fundamentals", StartDate = new DateTime(2019, 3, 5), EndDate = new DateTime(2019, 6, 10), Price = 220.0M},
                new Course {Name = "C# OOP", StartDate = new DateTime(2019, 5, 9), EndDate = new DateTime(2019, 10, 12), Price = 320.0M},
                new Course {Name = "C# Advanced", StartDate = new DateTime(2019, 2, 18), EndDate = new DateTime(2019, 6, 5), Price = 150.0M},
            };
            context.Courses.AddRange(courses);

            Resource[] resources = new[]
            {
                new Resource {Name = "C# data types", Url = "someUrl", ResourceType = ResourceType.Video, Course = courses[0]},
                new Resource {Name = "C# data types Lab", Url = "cdn url/document", ResourceType = ResourceType.Document, Course = courses[0]},
                new Resource {Name = "C# data types presentation", Url = "cdn url/presentation", ResourceType = ResourceType.Presentation, Course = courses[0]},
                new Resource {Name = "Random Resource", Url = "random Url", ResourceType = ResourceType.Other, Course = courses[1]},
            };
            context.Resources.AddRange(resources);

            Homework[] homeworks = new[]
            {
                new Homework {Content = "random content", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2019, 8, 3), Student = students[0], Course = courses[0]},
                new Homework {Content = "application", ContentType = ContentType.Application, SubmissionTime = new DateTime(2019, 8, 3), Student = students[0], Course = courses[1]},
                new Homework {Content = "zipped solution", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2019, 9, 13), Student = students[3], Course = courses[3]},
            };
            context.HomeworkSubmissions.AddRange(homeworks);

            context.SaveChanges();
        }
    }
}
