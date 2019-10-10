namespace P02_LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    class P02_LineNumbers
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                int letters = Regex.Matches(lines[i], "[A-Za-z]").Count;
                int punctuationMarks = Regex.Matches(lines[i], "[-,!.'?]").Count;
                string transformedLine = $"Line{i + 1}: {lines[i]} ({letters})({punctuationMarks})";

                File.AppendAllText("../../../output.txt", transformedLine + Environment.NewLine);
            }
        }
    }
}
