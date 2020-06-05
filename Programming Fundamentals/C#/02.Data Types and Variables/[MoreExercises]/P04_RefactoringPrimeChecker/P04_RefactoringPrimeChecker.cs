namespace P04_RefactoringPrimeChecker
{
    using System;

    class P04_RefactoringPrimeChecker
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            for (int i = 2; i <= times; i++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < i; divider++)
                {
                    if (i % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", i, (isPrime == true) ? "true" : "false");
            }
        }
    }
}