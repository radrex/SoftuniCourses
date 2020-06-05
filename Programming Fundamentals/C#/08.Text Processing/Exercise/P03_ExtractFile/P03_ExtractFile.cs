namespace P03_ExtractFile
{
    using System;
    using System.Linq;

    class P03_ExtractFile
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string file = path.Substring(path.LastIndexOf('\\') + 1);
            string fileExtension = file.Substring(file.IndexOf('.') + 1);
            string fileName = file.Substring(0, file.Length - fileExtension.Length - 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}