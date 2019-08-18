namespace P03_TreasureFinder
{
    using System;
    using System.Linq;

    class P03_TreasureFinder
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            while (true)
            {
                string message = Console.ReadLine();
                if (message == "find")
                {
                    break;
                }

                int keyIndex = 0;
                string decrypted = string.Empty;

                for (int i = 0; i < message.Length; i++)
                {
                    if (keyIndex >= keys.Length)
                    {
                        keyIndex = 0;
                    }

                    decrypted += (char)(message[i] - keys[keyIndex]);
                    keyIndex++;
                }

                int treasureStartIndex = decrypted.IndexOf('&');
                int treasureEndIndex = decrypted.LastIndexOf('&');
                string treasure = decrypted.Substring(treasureStartIndex + 1, treasureEndIndex - treasureStartIndex - 1);

                int coordinatesStartIndex = decrypted.IndexOf('<');
                int coordinatesEndIndex = decrypted.IndexOf('>');
                string coordinates = decrypted.Substring(coordinatesStartIndex + 1, coordinatesEndIndex - coordinatesStartIndex - 1);

                Console.WriteLine($"Found {treasure} at {coordinates}");
            }
        }
    }
}
