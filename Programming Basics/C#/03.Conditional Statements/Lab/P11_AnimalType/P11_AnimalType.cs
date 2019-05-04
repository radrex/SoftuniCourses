namespace P11_AnimalType
{
    using System;

    class P11_AnimalType
    {
        static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            switch (animalType)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;

                case "snake":
                case "crocodile":
                case "tortoise":
                    Console.WriteLine("reptile");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
