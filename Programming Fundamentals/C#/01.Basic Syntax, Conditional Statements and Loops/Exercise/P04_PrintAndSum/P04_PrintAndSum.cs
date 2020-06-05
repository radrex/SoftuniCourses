namespace P04_PrintAndSum
{
    using System;

    class P04_PrintAndSum
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            string sequence = string.Empty;
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                sequence += i + " ";
                sum += i;
            }

            Console.WriteLine(sequence.TrimEnd());
            Console.WriteLine($"Sum: {sum}");
        }
    }
}