namespace P03_OldestFamilyMember
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                family.AddMember(new Person(name, age));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
