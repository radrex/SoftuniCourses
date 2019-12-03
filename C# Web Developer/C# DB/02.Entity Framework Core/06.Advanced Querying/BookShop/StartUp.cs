namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db); // Comment after first Seed...

                //      01      string result = GetBooksByAgeRestriction(db, Console.ReadLine());
                //      02      string result = GetGoldenBooks(db);
                //      03      string result = GetBooksByPrice(db);
                //      04      string result = GetBooksNotReleasedIn(db, int.Parse(Console.ReadLine()));
                //      05      string result = GetBooksByCategory(db, Console.ReadLine());
                //      06      string result = GetBooksReleasedBefore(db, Console.ReadLine());
                //      07      string result = GetAuthorNamesEndingIn(db, Console.ReadLine());
                //      08      string result = GetBookTitlesContaining(db, Console.ReadLine());
                //      09      string result = GetBooksByAuthor(db, Console.ReadLine());
                //      10      int result = CountBooks(db, int.Parse(Console.ReadLine()));
                //      11      string result = CountCopiesByAuthor(db);
                //      12      string result = GetTotalProfitByCategory(db);
                //      13      string result = GetMostRecentBooks(db);
                //      14      IncreasePrices(db);
                //      15      int result = RemoveBooks(db);

                //Console.WriteLine(result);
            }
        }

        //------------------- TASK 01 ---- AGE RESTRICTION ----------------------------
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            context.Books
                   .Where(b => b.AgeRestriction.ToString().ToUpper() == command.ToUpper())
                   .Select(b => new
                   {
                       b.Title,
                   })
                   .OrderBy(b => b.Title)
                   .ToList()
                   .ForEach(b => sb.AppendLine(b.Title));
            
            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 02 ---- GOLDER BOOKS -------------------------------
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Books
                   .Where(b => b.Copies < 5000 && b.EditionType.ToString() == "Gold")
                   .Select(b => new
                   {
                       b.BookId,
                       b.Title,
                       b.EditionType,
                   })
                   .OrderBy(b => b.BookId)
                   .ToList()
                   .ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 03 ---- BOOKS BY PRICE -----------------------------
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Books
                   .Where(b => b.Price > 40)
                   .Select(b => new
                   {
                       b.Title,
                       b.Price,
                   })
                   .OrderByDescending(b => b.Price)
                   .ToList()
                   .ForEach(b => sb.AppendLine($"{b.Title} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 04 ---- NOT RELEASED IN ----------------------------
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();
            context.Books
                   .Where(b => b.ReleaseDate.Value.Year != year)
                   .Select(b => new
                   {
                       b.Title,
                       b.BookId,
                   })
                   .OrderBy(b => b.BookId)
                   .ToList()
                   .ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 05 ---- BOOK TITLES BY CATEGORY --------------------
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(c => c.ToUpper())
                                       .ToArray();

            context.Books
                   .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToUpper())))
                   .Select(b => b.Title)
                   .OrderBy(b => b)
                   .ToList()
                   .ForEach(b => sb.AppendLine(b));
                    
            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 06 ---- RELEASED BEFORE DATE -----------------------
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            context.Books
                   .Where(b => b.ReleaseDate.Value.Date < parsedDate.Date)
                   .Select(b => new 
                   {
                        b.ReleaseDate.Value.Date,
                        b.Title,
                        b.EditionType,
                        b.Price,
                   })
                   .OrderByDescending(b => b.Date)
                   .ToList()
                   .ForEach(b => sb.AppendLine($"{b.Title} - {b.EditionType.ToString()} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 07 ---- AUTHOR SEARCH ------------------------------
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            context.Authors
                   .Where(a => a.FirstName.EndsWith(input))
                   .Select(a => new
                   {
                       FullName = $"{a.FirstName} {a.LastName}",
                   })
                   .OrderBy(a => a.FullName)
                   .ToList()
                   .ForEach(a => sb.AppendLine(a.FullName));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 08 ---- BOOK SEARCH --------------------------------
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            context.Books
                   .Where(b => b.Title.ToUpper().Contains(input.ToUpper()))
                   .Select(b => b.Title)
                   .OrderBy(b => b)
                   .ToList()
                   .ForEach(b => sb.AppendLine(b));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 09 ---- BOOK SEARCH BY AUTHOR ----------------------
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            context.Books
                   .Where(b => b.Author.LastName.ToUpper().StartsWith(input.ToUpper()))
                   .Select(b => new
                   {
                       b.BookId,
                       b.Title,
                       AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}",
                   })
                   .OrderBy(b => b.BookId)
                   .ToList()
                   .ForEach(b => sb.AppendLine($"{b.Title} ({b.AuthorFullName})"));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 10 ---- COUNT BOOKS --------------------------------
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                          .Count(b => b.Title.Length > lengthCheck);
        }
        //------------------- TASK 11 ---- TOTAL BOOK COPIES --------------------------
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Authors
                   .Select(a => new
                   {
                       AuthorFullName = $"{a.FirstName} {a.LastName}",
                       BookCopies = a.Books.Sum(b => b.Copies),
                   })
                   .OrderByDescending(a => a.BookCopies)
                   .ToList()
                   .ForEach(a => sb.AppendLine($"{a.AuthorFullName} - {a.BookCopies}"));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 12 ---- PROFIT BY CATEGORY -------------------------
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Categories
                   .Select(c => new
                   {
                       c.Name,
                       TotalProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price),
                   })
                   .OrderByDescending(c => c.TotalProfit)
                   .ThenBy(c => c.Name)
                   .ToList()
                   .ForEach(c => sb.AppendLine($"{c.Name} ${c.TotalProfit:F2}"));

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 13 ---- MOST RECENT BOOKS --------------------------
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categories = context.Categories
                                    .Select(c => new
                                    {
                                        CategoryName = c.Name,
                                        Books = c.CategoryBooks.Select(b => new
                                        {
                                            b.Book.Title,
                                            b.Book.ReleaseDate,
                                        })
                                        .OrderByDescending(b => b.ReleaseDate)
                                        .Take(3)
                                        .ToList()
                                    })
                                    .OrderBy(c => c.CategoryName)
                                    .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 14 ---- INCREASE PRICES ----------------------------
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                   .Where(b => b.ReleaseDate.Value.Year < 2010)
                   .ToList()
                   .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }
        //------------------- TASK 15 ---- REMOVE BOOKS -------------------------------
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                               .Where(b => b.Copies < 4200)
                               .ToList();

            context.RemoveRange(books);
            context.SaveChanges();
            return books.Count();
        }
    }
}
