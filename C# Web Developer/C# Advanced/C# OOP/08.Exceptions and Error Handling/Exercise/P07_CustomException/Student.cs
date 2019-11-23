namespace P07_CustomException
{
    using System.Text.RegularExpressions;

    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get => this.name;
            set
            {
                string pattern = @"[\W_\d]";
                if (Regex.Match(value, pattern).Success)
                {
                    throw new InvalidPersonNameException("Invalid person name.");
                }
                this.name = value;
            }
        }

        public string Email
        {
            get => this.email;
            set
            {
                if (!Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    throw new InvalidPersonNameException("Invalid email.");
                }
                this.email = value;
            }
        }
    }
}
