namespace P08_MilitaryElite.Models
{
    using Contracts;

    public abstract class Soldier : ISoldier
    {
        //------------- Constructors ---------------
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        //-------------- Properties ----------------
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
