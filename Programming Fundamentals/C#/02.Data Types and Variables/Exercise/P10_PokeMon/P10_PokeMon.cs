namespace P10_PokeMon
{
    using System;

    class P10_PokeMon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int currentPokePower = pokePower;
            int targetsCount = 0;

            while (currentPokePower >= distance)
            {
                currentPokePower -= distance;
                targetsCount++;

                if (currentPokePower == pokePower * 0.5 && exhaustionFactor != 0)
                {
                    currentPokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPokePower);
            Console.WriteLine(targetsCount);
        }
    }
}