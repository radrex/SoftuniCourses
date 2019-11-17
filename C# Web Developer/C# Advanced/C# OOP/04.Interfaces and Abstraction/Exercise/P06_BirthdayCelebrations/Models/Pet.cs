namespace P06_BirthdayCelebrations.Models
{
    using P06_BirthdayCelebrations.Interfaces;

    public class Pet : IBirthable
    {
        //------------------ Constructors --------------------
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        //------------------- Properties ---------------------
        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}
