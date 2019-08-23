namespace P06_WeddingSeats
{
    using System;

    class P06_WeddingSeats
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int oddSeats = int.Parse(Console.ReadLine());

            int sectorCounter = 0;
            int seats = 0;
            for (char firstSector = 'A'; firstSector <= lastSector; firstSector++)
            {
                for (int row = 1; row <= rows + sectorCounter; row++)
                {
                    if (row % 2 != 0)
                    {
                        for (int oddSeat = 97; oddSeat < 97 + oddSeats; oddSeat++)
                        {
                            seats++;
                            Console.WriteLine($"{firstSector}{row}{(char)oddSeat}");
                        }
                    }
                    else
                    {
                        for (int seat = 97; seat < 97 + oddSeats + 2; seat++)
                        {
                            seats++;
                            Console.WriteLine($"{firstSector}{row}{(char)seat}");
                        }
                    }
                }

                sectorCounter++;
            }

            Console.WriteLine(seats);
        }
    }
}
