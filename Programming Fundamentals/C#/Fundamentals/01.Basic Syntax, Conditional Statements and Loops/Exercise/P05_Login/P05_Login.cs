namespace P05_Login
{
    using System;

    class P05_Login
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string usernameReversed = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                usernameReversed += username[i];
            }

            int stopCounter = 1;
            while (password != usernameReversed)
            {
                if (stopCounter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                stopCounter++;

                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}