namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        //-------------Constructors--------------
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        //--------------Properties---------------
        public Dictionary<string, Student> Repo { get; private set; }

        //---------------Methods-----------------
        public void ParseCommand(string command)
        {
            string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "Create":
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    double grade = double.Parse(tokens[3]);
                    Student student = new Student(name, age, grade);
                    Create(student);
                    break;

                case "Show":
                    string studentName = tokens[1];
                    Show(studentName);
                    break;

                case "Exit":
                    Exit();
                    break;
            }
        }

        public void Create(Student student)
        {
            if (!this.Repo.ContainsKey(student.Name))
            {
                this.Repo.Add(student.Name, student);
            }
        }

        public void Show(string studentName)
        {
            if (this.Repo.ContainsKey(studentName))
            {
                Student student = this.Repo[studentName];
                Console.WriteLine(student.ToString());
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
