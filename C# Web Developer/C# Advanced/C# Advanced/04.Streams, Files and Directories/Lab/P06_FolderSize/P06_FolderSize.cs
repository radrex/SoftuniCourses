namespace P06_FolderSize
{
    using System;
    using System.IO;

    class P06_FolderSize
    {
        static void Main(string[] args)
        {
            double size = GetLength("../../../TestFolder");
            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                writer.WriteLine(size);
            }
        }

        static double GetLength(string directory)
        {
            double size = 0;
            string[] files = Directory.GetFiles(directory);
            string[] subDirectories = Directory.GetDirectories(directory);

            foreach (string subDirectory in subDirectories)
            {
                size += GetLength(subDirectory);
            }

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            return size * 0.000001;
        }
    }
}
