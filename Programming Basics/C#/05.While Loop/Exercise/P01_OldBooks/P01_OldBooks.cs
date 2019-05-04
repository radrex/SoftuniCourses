namespace P01_OldBooks
{
    using System;

    class P01_OldBooks
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            int numberOfBooks = int.Parse(Console.ReadLine());

            int counter = 0;
            bool bookIsFound = false;

            string nextBook = Console.ReadLine();
            while (counter < numberOfBooks)
            {
                if (nextBook == favoriteBook)
                {
                    bookIsFound = true;
                    break;
                }

                counter++;
                nextBook = Console.ReadLine();
            }

            if (!bookIsFound)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {numberOfBooks} books.");
            }
            else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
