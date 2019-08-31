namespace P09_SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    class P09_SimpleTextEditor
    {
        static void Main(string[] args)
        {
            Stack<string> text = new Stack<string>();
            string processedText = String.Empty;

            int operations = int.Parse(Console.ReadLine());
            for (int i = 0; i < operations; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                switch (int.Parse(tokens[0]))
                {
                    case 1:
                        text.Push(processedText);
                        processedText += tokens[1];
                        break;
                    case 2:
                        text.Push(processedText);
                        processedText = processedText.Substring(0, processedText.Length - int.Parse(tokens[1]));
                        break;
                    case 3:
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(processedText[index - 1]);
                        break;
                    case 4:
                        processedText = text.Pop();
                        break;
                }
            }
        }
    }
}
