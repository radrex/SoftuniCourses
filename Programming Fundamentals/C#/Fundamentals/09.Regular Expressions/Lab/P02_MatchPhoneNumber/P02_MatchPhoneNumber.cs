namespace P02_MatchPhoneNumber
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class P02_MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359(-| )2\1\d{3}\1\d{4}\b";
            string phones = Console.ReadLine();

            MatchCollection matches = Regex.Matches(phones, pattern);

            string[] matchedPhones = matches.Cast<Match>()
                                            .Select(x => x.Value.Trim())
                                            .ToArray();

            Console.WriteLine(String.Join(", ", matchedPhones));
        }
    }
}
