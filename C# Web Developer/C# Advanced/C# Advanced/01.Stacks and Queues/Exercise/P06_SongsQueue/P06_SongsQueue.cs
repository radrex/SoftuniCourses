namespace P06_SongsQueue
{
    using System;
    using System.Collections.Generic;

    class P06_SongsQueue
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>();

            foreach (string song in songs)
            {
                if (!queue.Contains(song))
                {
                    queue.Enqueue(song);               
                }
            }

            while (queue.Count != 0)
            {
                string data = Console.ReadLine();
                string command = data.Substring(0, 4);

                switch (command)
                {
                    case "Play":
                        queue.Dequeue();
                        break;

                    case "Add ":
                        string song = data.Substring(4, data.Length - 4);
                        if (!queue.Contains(song))
                        {
                            queue.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;

                    case "Show":
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}