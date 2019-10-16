namespace P03_OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        //-------------- Constructors --------------
        public Family()
        {
            this.People = new List<Person>();
        }

        //--------------- Properties ---------------
        public List<Person> People { get; private set; }

        //---------------- Methods -----------------
        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(a => a.Age).FirstOrDefault();
        }
    }
}
