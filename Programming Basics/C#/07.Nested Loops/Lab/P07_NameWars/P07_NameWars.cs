namespace P07_NameWars
{
    using System;

    class P07_NameWars
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int maxSum = int.MinValue;
            string winner = string.Empty;

            while (name != "STOP")
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    winner = name;
                }
                name = Console.ReadLine();
            }

            Console.WriteLine($"Winner is {winner} - {maxSum}!");
        }
    }
}
