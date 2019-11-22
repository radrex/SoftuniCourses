namespace P03_DetailPrinter_After
{
    public class Employee : IEmployee
    {
        //---------- Constructors ----------
        public Employee(string name)
        {
            this.Name = name;
        }

        //----------- Properties -----------
        public string Name { get; private set; }

        //------------ Methods -------------
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
