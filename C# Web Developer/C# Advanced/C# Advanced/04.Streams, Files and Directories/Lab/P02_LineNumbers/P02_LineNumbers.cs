namespace P02_LineNumbers
{
    using System.IO;

    class P02_LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine($"{++counter}. {line}");
                    }
                }
            }
        }
    }
}
