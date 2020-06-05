namespace P10_LadyBugs
{
    using System;
    using System.Linq;

    class P10_LadyBugs
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugs = new int[fieldSize];
            int[] initialIndexes = Console.ReadLine()
                                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            for (int i = 0; i < ladyBugs.Length; i++) // Fill bugs on field
            {
                if (initialIndexes.Contains(i))
                {
                    ladyBugs[i] = 1;
                }
            }
            //------------------------------------------------------------------------------------------

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0].ToLower() != "end")
            {
                int index = int.Parse(command[0]);

                if (index < 0 || index >= ladyBugs.Length)   // If index is inside the field
                {
                    command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (ladyBugs[index] == 0)   // cell is empty (NO Lady Bug)
                {
                    command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                //------------- Fly like the wind -------------
                string direction = command[1];
                int flyLength = int.Parse(command[2]);
                if (flyLength < 0)  // If flyLength is negative, change direction, and make it positive
                {
                    flyLength = Math.Abs(flyLength);
                    switch (direction)
                    {
                        case "right":
                            direction = "left";
                            break;
                        case "left":
                            direction = "right";
                            break;
                    }
                }

                ladyBugs[index] = 0; // Lift off in 3...2...1
                bool isBugFlying = true;
                while (isBugFlying)
                {
                    switch (direction)
                    {
                        case "right":
                            if (index + flyLength >= ladyBugs.Length) // Lady Bug flew away (outside field)
                            {
                                isBugFlying = false;
                            }
                            else
                            {
                                if (ladyBugs[index + flyLength] == 0) //  is cell empty (no Lady Bug at index)
                                {
                                    ladyBugs[index + flyLength] = 1; // Lady Bug landed
                                    isBugFlying = false;
                                }
                                else
                                {
                                    isBugFlying = true; // Lady Bug continues to fly
                                    index += flyLength;
                                }
                            }
                            break;

                        case "left":
                            if (index - flyLength < 0) // Lady Bug flew away (outside field)
                            {
                                isBugFlying = false;
                            }
                            else
                            {
                                if (ladyBugs[index - flyLength] == 0) //  is cell empty (no Lady Bug at index)
                                {
                                    ladyBugs[index - flyLength] = 1; // Lady Bug landed
                                    isBugFlying = false;
                                }
                                else
                                {
                                    isBugFlying = true; // Lady Bug continues to fly
                                    index -= flyLength;
                                }
                            }
                            break;
                    }
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(String.Join(" ", ladyBugs));
        }
    }
}