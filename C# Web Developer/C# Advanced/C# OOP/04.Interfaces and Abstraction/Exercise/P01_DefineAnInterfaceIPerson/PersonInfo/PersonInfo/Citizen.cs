namespace PersonInfo
{
    public class Citizen : IPerson
    {
        //----------- Constructors -------------
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //------------ Properties --------------
        public string Name { get; }
        public int Age { get; }
    }
}
