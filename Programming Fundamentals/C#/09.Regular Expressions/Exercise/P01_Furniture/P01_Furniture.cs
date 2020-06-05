namespace P01_Furniture
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class P01_Furniture
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)";
            decimal sum = 0.0M;
            List<string> furnitureList = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }

                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match furniture in matches)
                {
                    furnitureList.Add(furniture.Groups["furniture"].Value);
                    sum += decimal.Parse(furniture.Groups["price"].Value) * int.Parse(furniture.Groups["quantity"].Value);
                }
            }

            Console.WriteLine("Bought furniture:");
            if (furnitureList.Count != 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, furnitureList));
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
