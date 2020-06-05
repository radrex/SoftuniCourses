namespace P01_MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    class P01_MatchFullName
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string names = Console.ReadLine();

            MatchCollection matches = Regex.Matches(names, pattern);
            string validNames = string.Empty;

            foreach (Match name in matches)
            {
                validNames += name.Value + " ";
            }

            Console.WriteLine(validNames.TrimEnd());
        }
    }
}
