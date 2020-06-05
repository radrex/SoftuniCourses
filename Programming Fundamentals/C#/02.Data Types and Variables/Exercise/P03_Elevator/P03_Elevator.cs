namespace P03_Elevator
{
    using System;

    class P03_Elevator
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)people / elevatorCapacity);

            Console.WriteLine(courses);
        }
    }
}