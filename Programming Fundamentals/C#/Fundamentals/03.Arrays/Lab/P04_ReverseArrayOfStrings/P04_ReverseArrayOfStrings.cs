namespace P04_ReverseArrayOfStrings
{
    using System;

    class P04_ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            Array.Reverse(strings);

            Console.WriteLine(String.Join(" ", strings));
        }
    }
}