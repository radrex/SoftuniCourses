namespace P03_Ferrari
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            IDriveable ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
