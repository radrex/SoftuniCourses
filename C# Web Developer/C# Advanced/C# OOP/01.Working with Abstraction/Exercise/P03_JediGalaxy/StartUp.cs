namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Galaxy galaxy = new Galaxy(dimensions[0], dimensions[1]);

            long sum = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Let the Force be with you")
                {
                    break;
                }

                int[] ivoCoordinates = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Player ivo = new Player(ivoCoordinates[0], ivoCoordinates[1]);
                int[] evilCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Player evil = new Player(evilCoordinates[0], evilCoordinates[1]);

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (evil.Row < galaxy.DimensionX && evil.Col < galaxy.DimensionY)
                    {
                        galaxy.GalaxyStars[evil.Row, evil.Col] = 0;
                    }

                    evil.MoveTopLeftDiagonal();
                }

                while (ivo.Row >= 0 && ivo.Col < galaxy.DimensionY)
                {
                    if (ivo.Row < galaxy.DimensionX && ivo.Col >= 0)
                    {
                        sum += galaxy.GalaxyStars[ivo.Row, ivo.Col];
                    }

                    ivo.MoveTopRightDiagonal();
                }
            }

            Console.WriteLine(sum);
        }
    }
}
