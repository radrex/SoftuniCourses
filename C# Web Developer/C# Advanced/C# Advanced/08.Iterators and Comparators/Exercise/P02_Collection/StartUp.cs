namespace P02_Collection
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(tokens.Skip(1).ToArray());
                        break;

                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "PrintAll":
                        string message = String.Empty;
                        foreach (string element in listyIterator)
                        {
                            message += element + " ";
                        }

                        Console.WriteLine(message.TrimEnd());
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
