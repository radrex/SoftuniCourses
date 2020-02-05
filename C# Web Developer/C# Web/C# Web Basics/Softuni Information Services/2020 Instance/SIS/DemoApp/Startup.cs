namespace DemoApp
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SIS.HTTP.Response;

    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Post, "/Tweets/Create", CreateTweet));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));
        }

        public void ConfigureServices()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }

        /// <summary>
        /// Returns the requested <see cref="HtmlResponse"/> for the Index page.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>HTML Response</returns>
        public static HttpResponse Index(HttpRequest request)
        {
            string username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            StringBuilder html = new StringBuilder();

            ApplicationDbContext db = new ApplicationDbContext();
            var tweets = db.Tweets.Select(x => new
            {
                x.CreatedOn,
                x.Creator,
                x.Content,
            })
            .ToList();

            html.Append("<table><tr><th>Date</th><th>Creator</th><th>Content</th></tr>");
            foreach (var tweet in tweets)
            {
                html.Append($"<tr><td>{tweet.CreatedOn}</td><td>{tweet.Creator}</td><td>{tweet.Content}</td></tr>");
            }
            html.Append("</table>");
            html.Append("<form action='/Tweets/Create' method='post'><input name='creator' /><br /><textarea name='tweetName'></textarea><br /><input type='submit' /></form>");

            return new HtmlResponse(html.ToString());
        }

        /// <summary>
        /// Returns the requested <see cref="FileResponse"/> for the favicon.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>File Response</returns>
        public static HttpResponse FavIcon(HttpRequest request)
        {
            //TODO: Add MIME Types enum ... image/x-icon ...
            byte[] byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }

        /// <summary>
        /// Adds new tweet to the database and returns <see cref="RedirectResponse"/> to another page.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>Redirect Response</returns>
        private static HttpResponse CreateTweet(HttpRequest request)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Tweets.Add(new Tweet
            {
                CreatedOn = DateTime.UtcNow,
                Creator = request.FormData["creator"],
                Content = request.FormData["tweetName"],
            });
            db.SaveChanges();

            return new RedirectResponse("/");
        }
    }
}
