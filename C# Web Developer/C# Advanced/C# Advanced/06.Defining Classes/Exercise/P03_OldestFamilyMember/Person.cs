namespace P03_OldestFamilyMember
{
    public class Person
    {
        //----------------- Fields -----------------
        private string name;
        private int age;

        //-------------- Constructors --------------
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //--------------- Properties ---------------
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        //---------------- Methods -----------------
        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
