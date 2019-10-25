namespace P03_Stack
{
    using System;
    using System.Linq;

    class P03_Stack
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Push":
                        int[] elements = tokens.Skip(1)
                                               .Select(i => i.Split(',').First())
                                               .Select(int.Parse)
                                               .ToArray();
                        stack.Push(elements);
                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }
            }

            foreach (int number in stack)
            {
                Console.WriteLine(number);
            }

            foreach (int number in stack)
            {
                Console.WriteLine(number);
            }
        }
    }
}
