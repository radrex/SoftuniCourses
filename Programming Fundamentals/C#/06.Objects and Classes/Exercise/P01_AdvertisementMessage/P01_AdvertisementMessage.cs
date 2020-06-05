namespace P01_AdvertisementMessage
{
    using System;

    class P01_AdvertisementMessage
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
                                              "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                                             "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());
            string message = string.Empty;

            while (n > 0)
            {
                message += GetRandomMessage(phrases) + " ";
                message += GetRandomMessage(events) + " ";
                message += GetRandomMessage(authors) + " ";
                message += GetRandomMessage(cities) + " ";

                Console.WriteLine(message);
                message = string.Empty;
                n--;
            }
        }

        public static string GetRandomMessage(string[] dataArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, dataArray.Length - 1);
            return dataArray[randomIndex];
        }
    }
}
