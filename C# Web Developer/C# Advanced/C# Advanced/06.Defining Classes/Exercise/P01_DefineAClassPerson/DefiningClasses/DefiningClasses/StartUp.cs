namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person
            {
                Name = "Pesho",
                Age = 20
            };

            Person person2 = new Person();
            person2.Name = "Gosho";
            person2.Age = 18;

            Person person3 = new Person();
            person2.Name = "Stamat";
            person2.Age = 43;
        }
    }
}
