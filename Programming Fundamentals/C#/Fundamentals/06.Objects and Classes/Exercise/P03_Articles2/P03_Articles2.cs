namespace P03_Articles2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P03_Articles2
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine().Split(", ");
                Article article = new Article()
                {
                    Title = articleData[0],
                    Content = articleData[1],
                    Author = articleData[2]
                };

                articles.Add(article);
            }

            string criteria = Console.ReadLine();
            switch (criteria)
            {
                case "title":
                    articles = articles.OrderBy(a => a.Title).ToList();
                    break;

                case "content":
                    articles = articles.OrderBy(a => a.Content).ToList();
                    break;

                case "author":
                    articles = articles.OrderBy(a => a.Author).ToList();
                    break;
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        //------------- Constructors ----------------
        public Article()
        {

        }

        //-------------- Properties -----------------
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        //--------------- Methods -------------------
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}