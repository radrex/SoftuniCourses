namespace PersonsInfo
{
    public class Person
    {
        //------------------- Constructors ---------------------
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        //-------------------- Properties ----------------------
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        //---------------------- Methods -----------------------
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
