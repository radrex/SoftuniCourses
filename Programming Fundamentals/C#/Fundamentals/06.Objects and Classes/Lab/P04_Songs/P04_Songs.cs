namespace P04_Songs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_Songs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('_');
                Song song = new Song()
                {
                    TypeList = data[0],
                    Name = data[1],
                    Time = data[2]
                };

                songs.Add(song);
            }

            string command = Console.ReadLine();
            if (command != "all")
            {
                songs.Where(s => s.TypeList == command)
                     .ToList()
                     .ForEach(s => Console.WriteLine(s.Name));
                return;
            }

            songs.ForEach(s => Console.WriteLine(s.Name));
        }
    }

    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}