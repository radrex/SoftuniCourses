namespace P04_FruitOrVegetable
{
    using System;

    class P04_FruitOrVegetable
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();

            switch (product)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit");
                    break;

                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
