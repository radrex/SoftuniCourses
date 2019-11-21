namespace ValidationAttributes
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        //------------------- Constructors ---------------------
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        //-------------------- Properties ----------------------
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(12, 95)]
        public int Age { get; set; }
    }
}
