namespace P06_BalancedBrackets
{
    using System;

    class P06_BalancedBrackets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int openedBracket = 0;
            int closedBracket = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "(":
                        openedBracket++;
                        if (openedBracket - closedBracket > 1)
                        {
                            Console.WriteLine("UNBALANCED");
                            return;
                        }
                        break;

                    case ")":
                        closedBracket++;
                        if (openedBracket - closedBracket != 0)
                        {
                            Console.WriteLine("UNBALANCED");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine((openedBracket == closedBracket) ? "BALANCED" : "UNBALANCED");
        }
    }
}