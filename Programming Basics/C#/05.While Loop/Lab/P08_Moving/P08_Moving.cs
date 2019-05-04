namespace P08_Moving
{
    using System;

    class P08_Moving
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * length * height;
            int totalSpace = 0;
            int spaceDiff = 0;

            string command = Console.ReadLine();
            while (command != "Done")
            {
                int cartoonSpace = int.Parse(command);
                totalSpace += cartoonSpace;
                spaceDiff = Math.Abs(totalSpace - freeSpace);

                if (totalSpace >= freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {spaceDiff} Cubic meters more.");
                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "Done")
            {
                Console.WriteLine($"{spaceDiff} Cubic meters left.");
            }
        }
    }
}
