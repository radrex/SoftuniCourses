namespace P08_SecretDoorsLock
{
    using System;

    class P08_SecretDoorsLock
    {
        static void Main(string[] args)
        {
            int hundreds = int.Parse(Console.ReadLine());
            int tens = int.Parse(Console.ReadLine());
            int ones = int.Parse(Console.ReadLine());

            for (int x1 = 1; x1 <= hundreds; x1++)
            {
                if (x1 % 2 == 0)
                {
                    for (int x2 = 1; x2 <= tens; x2++)
                    {
                        if (x2 == 2 || x2 == 3 || x2 == 5 || x2 == 7)
                        {
                            for (int x3 = 2; x3 <= ones; x3++)
                            {
                                if (x3 % 2 == 0)
                                {
                                    Console.WriteLine($"{x1} {x2} {x3}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
