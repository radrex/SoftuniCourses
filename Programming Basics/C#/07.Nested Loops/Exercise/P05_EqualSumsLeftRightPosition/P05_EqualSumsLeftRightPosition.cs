namespace P05_EqualSumsLeftRightPosition
{
    using System;

    class P05_EqualSumsLeftRightPosition
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            int sum1 = 0;
            int sum2 = 0;

            for (int i = int.Parse(firstNumber); i <= int.Parse(secondNumber); i++)
            {
                firstNumber = i.ToString();
                sum1 = (int)Char.GetNumericValue(firstNumber[0]) + (int)Char.GetNumericValue(firstNumber[1]);
                sum2 = (int)Char.GetNumericValue(firstNumber[3]) + (int)Char.GetNumericValue(firstNumber[4]);
                if (sum1 != sum2)
                {
                    if (sum1 > sum2)
                    {
                        sum2 += (int)Char.GetNumericValue(firstNumber[2]);
                    }
                    else
                    {
                        sum1 += (int)Char.GetNumericValue(firstNumber[2]);
                    }
                }

                if (sum1 == sum2)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
