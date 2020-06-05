namespace P01_WinningTicket
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class P01_WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                                      .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(x => x.Trim())
                                      .ToArray();

            string pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                Match leftSide = Regex.Match(ticket.Substring(0, 10), pattern);
                Match rightSide = Regex.Match(ticket.Substring(10), pattern);

                if (!leftSide.Success || !rightSide.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                int minLen = Math.Min(leftSide.Length, rightSide.Length);
                string left = leftSide.Value.Substring(0, minLen);
                string right = rightSide.Value.Substring(0, minLen);
                if (left.Equals(right))
                {
                    Console.WriteLine(left.Length == 10 ? $"ticket \"{ticket}\" - {minLen}{left.Substring(0, 1)} Jackpot!" :
                                                          $"ticket \"{ticket}\" - {minLen}{left.Substring(0, 1)}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}