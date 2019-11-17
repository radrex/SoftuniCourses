namespace P10_ExplicitInterfaces
{
    using Contracts;

    public class Citizen : IPerson, IResident
    {
        //----------- Constructors -------------
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
        //------------ Properties --------------
        public string Name { get; }

        public int Age { get; }

        public string Country { get; }

        //-------------- Methods ---------------
        string IPerson.GetName()
        {
            return this.Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
