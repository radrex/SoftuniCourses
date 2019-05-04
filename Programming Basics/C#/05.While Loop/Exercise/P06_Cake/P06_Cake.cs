namespace P06_Cake
{
    using System;

    class P06_Cake
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int pieces = width * length;

            string command = Console.ReadLine();
            while (command != "STOP")
            {
                int takenPieces = int.Parse(command);
                pieces -= takenPieces;

                if (pieces < 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (pieces > 0)
            {
                Console.WriteLine($"{pieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
            }
        }
    }
}
