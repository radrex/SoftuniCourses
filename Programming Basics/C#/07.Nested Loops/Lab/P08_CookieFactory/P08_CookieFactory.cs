namespace P08_CookieFactory
{
    using System;

    class P08_CookieFactory
    {
        static void Main(string[] args)
        {
            int batchesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= batchesCount; i++)
            {
                bool containsEggs = false;
                bool containsFlour = false;
                bool containsSugar = false;

                string ingredient = Console.ReadLine();
                while (true)
                {
                    if (ingredient == "eggs")
                    {
                        containsEggs = true;
                    }
                    else if (ingredient == "flour")
                    {
                        containsFlour = true;
                    }
                    else if (ingredient == "sugar")
                    {
                        containsSugar = true;
                    }
                    else if (ingredient == "Bake!")
                    {
                        if (containsEggs && containsFlour && containsSugar)
                        {
                            Console.WriteLine($"Baking batch number {i}...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                    }

                    ingredient = Console.ReadLine();
                }
            }
        }
    }
}
