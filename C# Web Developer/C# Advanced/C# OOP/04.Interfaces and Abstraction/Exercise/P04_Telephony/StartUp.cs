namespace P04_Telephony
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            foreach (string number in phones)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            foreach (string url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
