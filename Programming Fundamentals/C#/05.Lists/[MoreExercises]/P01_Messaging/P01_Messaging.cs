namespace P01_Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_Messaging
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            string message = Console.ReadLine();
            string result = string.Empty;

            foreach (int number in numbers)
            {
                string num = number.ToString();
                int index = 0;
                for (int i = 0; i < num.Length; i++)
                {
                    index += num[i] - '0';
                }

                while (index >= message.Length)
                {
                    index -= message.Length;
                }

                result += message[index];
                message = message.Remove(index, 1);
            }

            Console.WriteLine(result);
        }
    }
}