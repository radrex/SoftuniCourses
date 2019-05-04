namespace P06_SumPrimeNonPrime
{
    using System;

    class P06_SumPrimeNonPrime
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int sumPrime = 0;
            int sumNonPrime = 0;

            while (command != "stop")
            {
                int num = int.Parse(command);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                bool isPrime = true;
                if (num == 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = num; i >= 2; i--)
                    {
                        if (num % i == 0 && i != num)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                {
                    sumPrime += num;
                }
                else
                {
                    sumNonPrime += num;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
