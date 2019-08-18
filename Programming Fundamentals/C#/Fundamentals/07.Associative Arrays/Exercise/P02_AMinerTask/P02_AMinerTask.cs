namespace P02_AMinerTask
{
    using System;
    using System.Collections.Generic;

    class P02_AMinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string command = Console.ReadLine();
            string currentResource = string.Empty;
            int row = 1;
            while (command != "stop")
            {
                if (row % 2 != 0)   // Resource
                {
                    currentResource = command;
                    if (!resources.ContainsKey(currentResource))
                    {
                        resources.Add(currentResource, 0);
                    }
                }
                else
                {
                    resources[currentResource] += int.Parse(command);
                }

                row++;
                command = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine(String.Join(Environment.NewLine, $"{resource.Key} -> {resource.Value}"));
            }
        }
    }
}
