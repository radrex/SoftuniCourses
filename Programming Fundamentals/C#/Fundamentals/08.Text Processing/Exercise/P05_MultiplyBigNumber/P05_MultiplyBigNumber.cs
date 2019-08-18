namespace P05_MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;

    class P05_MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            string str = Convert.ToString('5');
            char[] num = Console.ReadLine().TrimStart('0').ToCharArray();
            int digit = int.Parse(Console.ReadLine());

            if (digit == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<string> multipliedNum = new List<string>();

            int multiplied = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                multiplied = (num[i] - '0') * digit + multiplied;
                multipliedNum.Add((multiplied % 10).ToString());
                multiplied /= 10;
            }

            multipliedNum.Reverse();
            if (multiplied > 0)
            {
                Console.WriteLine($"{multiplied}{String.Join("", multipliedNum)}");
            }
            else
            {
                Console.WriteLine(String.Join("", multipliedNum));
            }
        }
    }
}