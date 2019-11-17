namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        //----------- Constructors -------------
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        //------------ Properties --------------
        public string Name { get; }
        public int Age { get; }
        public string Birthdate { get; }
        public string Id { get; }
    }
}

