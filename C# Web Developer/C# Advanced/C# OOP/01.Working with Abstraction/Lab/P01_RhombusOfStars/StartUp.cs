namespace P01_RhombusOfStars
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            RhombusPrinter rhombusPrinter = new RhombusPrinter(size);
            Console.WriteLine(rhombusPrinter.Print(size));
        }
    }
}
