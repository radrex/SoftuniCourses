namespace P01_EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    class P01_EvenLines
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        Stack<string> stack = new Stack<string>(line.Split());
                        line = string.Empty;
                        while (stack.Count != 0)
                        {
                            string word = stack.Pop();
                            StringBuilder sb = new StringBuilder(word);
                            MatchCollection match = Regex.Matches(word, "[-,.!?]");
                            if (match.Count != 0)
                            {
                                foreach (Match symbol in match)
                                {
                                    int index = symbol.Index;
                                    sb[index] = '@';
                                }
                            }

                            line += sb + " ";
                        }

                        Console.WriteLine(line.TrimEnd());
                    }
                    counter++;
                }
            }
        }
    }
}
