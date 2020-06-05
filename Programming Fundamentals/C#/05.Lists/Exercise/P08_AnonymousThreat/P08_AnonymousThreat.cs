namespace P08_AnonymousThreat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P08_AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .ToList();

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "3:1")
            {
                switch (command[0])
                {
                    case "merge":
                        int start = int.Parse(command[1]);
                        int end = int.Parse(command[2]);
                        string merged = string.Empty;

                        if (start < 0 || start >= data.Count)
                        {
                            start = 0;
                        }

                        if (end >= data.Count || end < 0)
                        {
                            end = data.Count - 1;
                        }

                        for (int i = start; i <= end; i++)
                        {
                            merged += data[start];
                            data.RemoveAt(start);
                        }

                        data.Insert(start, merged);
                        break;

                    case "divide":
                        int index = int.Parse(command[1]);
                        int partitions = int.Parse(command[2]);
                        string element = data[index];
                        data.RemoveAt(index);   // Remove the element, later insert the divided elements at this index 1 by 1 starting with the longest

                        int iterator = element.Length / partitions;
                        for (int i = element.Length - 1; i >= 0; i -= iterator) // Start iterating BACKWARDS, so we can firstly add the longest element
                        {                                                       // The iterator step is equal to the short element's count (a, b, cd)
                            if (element.Length % partitions == 0)               //                                                    (1)    1  1  2
                            {
                                data.Insert(index, element.Substring(i - iterator + 1, iterator));
                            }
                            else
                            {
                                if (i == element.Length - 1)    // On the LAST INDEX, ADD LONGEST ELEMENT, then MOVE index backwards after that element
                                {
                                    int longestElementCount = (element.Length % partitions) + element.Length / partitions;
                                    data.Insert(index, element.Substring(element.Length - longestElementCount, longestElementCount));
                                    i = element.Length - longestElementCount;   // MOVE the index of the loop back, LONGEST ELEMENT ADDED
                                }
                                else
                                {
                                    data.Insert(index, element.Substring(i, iterator)); // ADD SHORT ELEMENTS
                                }
                            }
                        }

                        break;
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(String.Join(" ", data));
        }
    }
}