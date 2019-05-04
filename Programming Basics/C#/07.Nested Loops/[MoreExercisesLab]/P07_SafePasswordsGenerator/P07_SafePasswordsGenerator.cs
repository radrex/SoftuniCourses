namespace P07_SafePasswordsGenerator
{
    using System;

    class P07_SafePasswordsGenerator
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int passwords = int.Parse(Console.ReadLine());

            int A = 35;
            int B = 64;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    if (A > 55)
                    {
                        A = 35;
                    }
                    if (B > 96)
                    {
                        B = 64;
                    }

                    if (passwords == 0)
                    {
                        return;
                    }

                    Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");

                    A++;
                    B++;
                    passwords--;
                }
            }
        }
    }
}
