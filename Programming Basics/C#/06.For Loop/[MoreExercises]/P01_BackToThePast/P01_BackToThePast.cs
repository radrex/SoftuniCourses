namespace P01_BackToThePast
{
    using System;

    class P01_BackToThePast
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int age = 18;

            for (int i = 1800; i <= year; i++)
            {
                if (i % 2 == 0)
                {
                    money -= 12000;
                }
                else
                {
                    money -= 12000 + (age * 50);
                }

                age++;
            }

            Console.WriteLine(money < 0 ? $"He will need {Math.Abs(money):F2} dollars to survive." : 
                                          $"Yes! He will live a carefree life and will have {money:F2} dollars left.");
        }
    }
}
