namespace P03_StudentSystem
{
    using System.Text;

    public class Student
    {
        //-------------Constructors--------------
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        //--------------Properties---------------
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Grade { get; private set; }

        //---------------Methods-----------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} is {this.Age} years old. ");
            if (this.Grade >= 5)
            {
                sb.Append("Excellent student.");
            }
            else if (this.Grade >= 3.50)
            {
                sb.Append("Average student.");
            }
            else
            {
                sb.Append("Very nice person.");
            }

            return $"{sb}";
        }
    }
}
