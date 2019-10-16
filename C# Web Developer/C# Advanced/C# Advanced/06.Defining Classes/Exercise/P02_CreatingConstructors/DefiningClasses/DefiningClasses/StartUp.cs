namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Pesho";
            person1.Age = 20;

            Person person2 = new Person(18);

            Person person3 = new Person("Gosho", 43);
        }
    }
}
