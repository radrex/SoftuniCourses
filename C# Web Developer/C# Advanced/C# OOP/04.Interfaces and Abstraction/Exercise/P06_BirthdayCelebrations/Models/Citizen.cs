namespace P06_BirthdayCelebrations.Models
{
    using P06_BirthdayCelebrations.Interfaces;

    public class Citizen : IIdentifiable, IBirthable
    {
        //------------------ Constructors --------------------
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        //------------------- Properties ---------------------
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
    }
}
