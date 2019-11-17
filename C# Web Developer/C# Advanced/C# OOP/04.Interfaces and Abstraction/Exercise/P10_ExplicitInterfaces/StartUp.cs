namespace P10_ExplicitInterfaces
{
    using Contracts;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (data[0] != "End")
            {
                Citizen citizen = new Citizen(data[0], data[1], int.Parse(data[2]));
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
