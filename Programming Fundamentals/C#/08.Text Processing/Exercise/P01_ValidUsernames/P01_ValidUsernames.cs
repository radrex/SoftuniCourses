namespace P01_ValidUsernames
{
    using System;
    using System.Collections.Generic;

    class P01_ValidUsernames
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();

            foreach (string username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isValid = true;
                    foreach (char symbol in username)
                    {
                        if (!(char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_'))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }
    }
}