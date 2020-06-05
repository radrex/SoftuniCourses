namespace P11_Snowballs
{
    using System;
    using System.Numerics;

    class P11_Snowballs
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger bestSnowballValue = -10000000000;
            string message = string.Empty;

            for (int i = 0; i < snowballs; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snow / time), quality);
                if (snowballValue >= bestSnowballValue)
                {
                    bestSnowballValue = snowballValue;
                    message = $"{snow} : {time} = {bestSnowballValue} ({quality})";
                }
            }

            Console.WriteLine(message);
        }
    }
}