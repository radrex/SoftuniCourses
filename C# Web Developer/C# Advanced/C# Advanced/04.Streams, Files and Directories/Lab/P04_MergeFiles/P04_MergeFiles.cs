namespace P04_MergeFiles
{
    using System.IO;

    class P04_MergeFiles
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllLines("FileOne.txt");
            string[] file2 = File.ReadAllLines("FileTwo.txt");

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                int lineNumber = 0;
                while (lineNumber < file1.Length || lineNumber < file2.Length)
                {
                    if (lineNumber < file1.Length)
                    {
                        writer.WriteLine(file1[lineNumber]);
                    }

                    if (lineNumber < file2.Length)
                    {
                        writer.WriteLine(file2[lineNumber]);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
