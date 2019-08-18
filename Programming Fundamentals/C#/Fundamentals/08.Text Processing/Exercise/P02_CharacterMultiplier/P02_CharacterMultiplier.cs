namespace P02_CharacterMultiplier
{
    using System;
    using System.Linq;

    class P02_CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            int sum = SumCharValues(data[0], data[1]);
            Console.WriteLine(sum);
        }

        public static int SumCharValues(string str1, string str2)
        {
            int sum = 0;
            if (str1.Length > str2.Length)
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    sum += str1[i] * str2[i];
                }

                for (int i = str2.Length; i < str1.Length; i++)
                {
                    sum += str1[i];
                }
            }
            else if (str1.Length < str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += str1[i] * str2[i];
                }

                for (int i = str1.Length; i < str2.Length; i++)
                {
                    sum += str2[i];
                }
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += str1[i] * str2[i];
                }
            }

            return sum;
        }
    }
}