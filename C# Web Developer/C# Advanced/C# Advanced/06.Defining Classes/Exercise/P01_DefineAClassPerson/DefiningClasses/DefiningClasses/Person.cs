namespace DefiningClasses
{
    internal class Person
    {
        //----------------- Fields -----------------
        private string name;
        private int age;

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
    }
}
