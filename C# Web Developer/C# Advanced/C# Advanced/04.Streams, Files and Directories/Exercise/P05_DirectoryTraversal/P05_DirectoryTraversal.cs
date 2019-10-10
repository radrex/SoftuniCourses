namespace P05_DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class P05_DirectoryTraversal
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> directories = new Dictionary<string, Dictionary<string, decimal>>();
            string[] files = Directory.GetFiles("../../../", "*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);
                string fileName = Path.GetFileName(file);
                string extention = Path.GetExtension(file);
                decimal size = Decimal.Divide(currentFile.Length, 1024);

                if (!directories.ContainsKey(extention))
                {
                    directories.Add(extention, new Dictionary<string, decimal>());
                }
                if (!directories[extention].ContainsKey(fileName))
                {
                    directories[extention].Add(fileName, size);
                }
            }

            using (StreamWriter report = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (var extention in directories.OrderByDescending(f => f.Value.Count).ThenBy(n => n.Key))
                {
                    report.WriteLine($"{extention.Key}");
                    foreach (var file in extention.Value.OrderBy(f => f.Value))
                    {
                        report.WriteLine($"--{file.Key} - {file.Value:F2}kb");
                    }
                }
            }
        }
    }
}
