namespace P04_VowelsSum
{
    using System;

    class P04_VowelsSum
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                switch (letter)
                {
                    case 'a': sum++; break;
                    case 'e': sum += 2; break;
                    case 'i': sum += 3; break;
                    case 'o': sum += 4; break;
                    case 'u': sum += 5; break;
                    default: break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
