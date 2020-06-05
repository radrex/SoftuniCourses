namespace P06_CardsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P06_CardsGame
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                                         .Split()
                                         .Select(int.Parse)
                                         .ToList();
            List<int> secondHand = Console.ReadLine()
                                          .Split()
                                          .Select(int.Parse)
                                          .ToList();
            while (firstHand.Count > 0 && secondHand.Count > 0)
            {
                if (firstHand.First() > secondHand.First())
                {
                    firstHand.Add(firstHand.First());
                    firstHand.Add(secondHand.First());
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else if (firstHand.First() < secondHand.First())
                {
                    secondHand.Add(secondHand.First());
                    secondHand.Add(firstHand.First());
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }
                else
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
            }

            Console.WriteLine(firstHand.Count > 0 ? $"First player wins! Sum: {firstHand.Sum()}" : $"Second player wins! Sum: {secondHand.Sum()}");
        }
    }
}
