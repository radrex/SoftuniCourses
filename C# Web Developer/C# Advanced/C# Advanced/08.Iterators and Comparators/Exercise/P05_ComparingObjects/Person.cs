namespace P05_ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        //------------- Constructors ---------------
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        //-------------- Properties ----------------
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        //--------------- Methods ------------------
        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return this.Town.CompareTo(other.Town);
        }
    }
}
