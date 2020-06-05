namespace P05_PrintPartOfASCIITable
{
    using System;

    class P05_PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = start; i <= end; i++)
            {
                result += (char)i + " ";
            }

            result.TrimEnd();
            Console.WriteLine(result);
        }
    }
}