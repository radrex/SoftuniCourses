namespace P03_Substring
{
    using System;

    class P03_Substring
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string str = Console.ReadLine();

            while (true)
            {
                int index = str.ToLower().IndexOf(pattern.ToLower());
                if (index < 0)
                {
                    break;
                }
                str = str.Remove(index, pattern.Length);
            }

            Console.WriteLine(str);
        }
    }
}