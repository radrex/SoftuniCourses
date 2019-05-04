namespace P07_PetShop
{
    using System;

    class P07_PetShop
    {
        static void Main(string[] args)
        {
            int dogsCount = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            double totalSum = dogsCount * 2.5 + otherAnimals * 4;

            Console.WriteLine($"{totalSum:F2} lv.");
        }
    }
}
