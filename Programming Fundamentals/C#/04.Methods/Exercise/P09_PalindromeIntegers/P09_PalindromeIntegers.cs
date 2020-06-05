namespace P09_PalindromeIntegers
{
    using System;

    class P09_PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            while (input != "END")
            {
                int number = int.Parse(input);
                CheckPalindrome(number);

                input = Console.ReadLine().ToUpper();
            }
        }

        public static void CheckPalindrome(int number)
        {
            char[] numAsText = number.ToString().ToCharArray();
            Array.Reverse(numAsText);
            int num = int.Parse(new string(numAsText));

            Console.WriteLine(number == num ? "true" : "false");
        }
    }
}