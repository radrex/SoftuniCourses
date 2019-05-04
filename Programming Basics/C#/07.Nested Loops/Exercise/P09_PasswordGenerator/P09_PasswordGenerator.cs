namespace P09_PasswordGenerator
{
    using System;

    class P09_PasswordGenerator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int s1 = 1; s1 < n; s1++)
            {
                for (int s2 = 1; s2 < n; s2++)
                {
                    for (int s3 = 97; s3 < 97 + l; s3++)
                    {
                        for (int s4 = 97; s4 < 97 + l; s4++)
                        {
                            for (int s5 = 1; s5 <= n; s5++)
                            {
                                if (s5 > s1 && s5 > s2)
                                {
                                    Console.Write($"{s1}{s2}{(char)s3}{(char)s4}{s5} ");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
