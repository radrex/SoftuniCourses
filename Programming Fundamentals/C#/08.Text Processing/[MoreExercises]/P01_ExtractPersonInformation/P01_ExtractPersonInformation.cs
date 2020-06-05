namespace P01_ExtractPersonInformation
{
    using System;

    class P01_ExtractPersonInformation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                int nameStartIndex = message.IndexOf('@');
                int nameEndIndex = message.IndexOf('|');
                string name = message.Substring(nameStartIndex + 1, nameEndIndex - nameStartIndex - 1);


                int ageStartIndex = message.IndexOf('#');
                int ageEndIndex = message.IndexOf('*');
                string age = message.Substring(ageStartIndex + 1, ageEndIndex - ageStartIndex - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
