namespace P07_ConcatNames
{
    using System;

    class P07_ConcatNames
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine($"{firstName}{delimeter}{lastName}");
        }
    }
}