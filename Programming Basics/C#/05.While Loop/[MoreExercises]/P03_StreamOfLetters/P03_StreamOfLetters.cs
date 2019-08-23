namespace P03_StreamOfLetters
{
    using System;

    class P03_StreamOfLetters
    {
        static void Main(string[] args)
        {
            bool isMatched_C = false;
            bool isMatched_O = false;
            bool isMatched_N = false;

            string word = string.Empty;
            string currentWord = string.Empty;

            while (true)
            {
                if (isMatched_C && isMatched_O && isMatched_N)
                {
                    word += currentWord + " ";
                    currentWord = string.Empty;
                    isMatched_C = false;
                    isMatched_O = false;
                    isMatched_N = false;
                }

                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine(word);
                    break;
                }

                char symbol = char.Parse(command);
                if ((symbol >= 65 && symbol <= 90) || (symbol >= 97 && symbol <= 122))
                {
                    if (symbol == 'c')
                    {
                        if (isMatched_C)
                        {
                            currentWord += symbol;
                        }
                        else
                        {
                            isMatched_C = true;
                        }
                    }
                    else if (symbol == 'o')
                    {
                        if (isMatched_O)
                        {
                            currentWord += symbol;
                        }
                        else
                        {
                            isMatched_O = true;
                        }
                    }
                    else if (symbol == 'n')
                    {
                        if (isMatched_N)
                        {
                            currentWord += symbol;
                        }
                        else
                        {
                            isMatched_N = true;
                        }                    
                    }
                    else
                    {
                        currentWord += symbol;
                    }
                }
            }
        }
    }
}
