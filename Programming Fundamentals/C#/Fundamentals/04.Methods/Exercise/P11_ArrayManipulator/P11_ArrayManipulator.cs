namespace P11_ArrayManipulator
{
    using System;
    using System.Linq;

    class P11_ArrayManipulator
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                string message = string.Empty;
                switch (command[0])
                {
                    case "exchange":
                        Exchange(initialArray, command);
                        command = Console.ReadLine().Split();
                        continue;

                    case "max":
                        int index = Max(initialArray, command);
                        message = (index >= 0) ? $"{index}" : "No matches";
                        break;

                    case "min":
                        index = Min(initialArray, command);
                        message = (index >= 0) ? $"{index}" : "No matches";
                        break;

                    case "first":
                        int count = int.Parse(command[1]);
                        if (count > initialArray.Length)
                        {
                            message = "Invalid count";
                            break;
                        }

                        string evenOrOdd = command[2];
                        int[] nums = First(initialArray, count, evenOrOdd);

                        message = (nums.Length == 0 ? "[]" : $"[{String.Join(", ", nums)}]");
                        break;

                    case "last":
                        count = int.Parse(command[1]);
                        if (count > initialArray.Length)
                        {
                            message = "Invalid count";
                            break;
                        }

                        evenOrOdd = command[2];
                        nums = Last(initialArray, count, evenOrOdd);
                        message = (nums.Length == 0 ? "[]" : $"[{String.Join(", ", nums)}]");
                        break;
                }

                Console.WriteLine(message);
                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{String.Join(", ", initialArray)}]");
        }

        public static void Exchange(int[] initialArray, string[] command)
        {
            int index = int.Parse(command[1]);
            if (index < 0 || index >= initialArray.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            int[] leftSide = new int[index + 1];
            int[] rightSide = new int[initialArray.Length - 1 - index];
            int counter = 0;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (i < leftSide.Length)
                {
                    leftSide[i] = initialArray[i];
                }
                else
                {
                    rightSide[counter] = initialArray[i];
                    counter++;
                }
            }

            counter = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (i < rightSide.Length)
                {
                    initialArray[i] = rightSide[i];
                }
                else
                {
                    initialArray[i] = leftSide[counter++];
                }
            }
        }

        public static int Max(int[] initialArray, string[] command)
        {
            int max = int.MinValue;
            int index = -1;

            switch (command[1])
            {
                case "even":
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        if (initialArray[i] % 2 == 0 && initialArray[i] >= max)
                        {
                            max = initialArray[i];
                            index = i;
                        }
                    }

                    break;

                case "odd":
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        if (initialArray[i] % 2 != 0 && initialArray[i] >= max)
                        {
                            max = initialArray[i];
                            index = i;
                        }
                    }

                    break;
            }

            return index;
        }

        public static int Min(int[] initialArray, string[] command)
        {
            int min = int.MaxValue;
            int index = -1;
            switch (command[1])
            {
                case "even":
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        if (initialArray[i] % 2 == 0 && initialArray[i] <= min)
                        {
                            min = initialArray[i];
                            index = i;
                        }
                    }

                    break;

                case "odd":
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        if (initialArray[i] % 2 != 0 && initialArray[i] <= min)
                        {
                            min = initialArray[i];
                            index = i;
                        }
                    }

                    break;
            }

            return index;
        }

        public static int[] First(int[] initialArray, int count, string evenOrOdd)
        {
            string nums = string.Empty;
            switch (evenOrOdd)
            {
                case "even":
                    foreach (int digit in initialArray)
                    {
                        if (count > 0 && digit % 2 == 0)
                        {
                            nums += $"{digit} ";
                            count--;
                        }
                    }
                    break;

                case "odd":
                    foreach (int digit in initialArray)
                    {
                        if (count > 0 && digit % 2 != 0)
                        {
                            nums += $"{digit} ";
                            count--;
                        }
                    }
                    break;
            }
            nums.TrimEnd();

            return nums.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();
        }

        public static int[] Last(int[] initialArray, int count, string evenOrOdd)
        {
            string nums = string.Empty;
            switch (evenOrOdd)
            {
                case "even":
                    for (int i = initialArray.Length - 1; i >= 0; i--)
                    {
                        if (count > 0 && initialArray[i] % 2 == 0)
                        {
                            nums += $"{initialArray[i]} ";
                            count--;
                        }
                    }
                    break;

                case "odd":
                    for (int i = initialArray.Length - 1; i >= 0; i--)
                    {
                        if (count > 0 && initialArray[i] % 2 != 0)
                        {
                            nums += $"{initialArray[i]} ";
                            count--;
                        }
                    }
                    break;
            }
            nums.TrimEnd();

            return nums.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray()
                       .Reverse()
                       .ToArray();
        }
    }
}