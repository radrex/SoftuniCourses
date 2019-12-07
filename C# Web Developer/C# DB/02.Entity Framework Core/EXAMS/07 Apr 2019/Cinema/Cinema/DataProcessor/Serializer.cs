namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            ExportTopMoviesDto[] movies = context.Movies
                                 .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count >= 1))
                                 .OrderByDescending(m => m.Rating)
                                 .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                                 .Select(m => new ExportTopMoviesDto
                                 {
                                     MovieName = m.Title,
                                     Rating = m.Rating.ToString("F2"),
                                     TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                                     Customers = m.Projections.SelectMany(p => p.Tickets)
                                                              .Select(c => new ExportCustomerBalanceDto
                                                                           {
                                                                               FirstName = c.Customer.FirstName,
                                                                               LastName = c.Customer.LastName,
                                                                               Balance = c.Customer.Balance.ToString("F2"),
                                                                           })
                                                                           .OrderByDescending(c => c.Balance)
                                                                           .ThenBy(c => c.FirstName)
                                                                           .ThenBy(c => c.LastName)
                                                                           .ToArray()
                                 })
                                 .Take(10)
                                 .ToArray();

            string json = JsonConvert.SerializeObject(movies, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {

            ExportTopCustomerDto[] customers = context.Customers.Where(c => c.Age >= age)
                                                                .Select(c => new ExportTopCustomerDto
                                                                {
                                                                    FirstName = c.FirstName,
                                                                    LastName = c.LastName,
                                                                    SpentMoney = $"{c.Tickets.Sum(t => t.Price):F2}", // TODO Wrong calculations 

                                                                    SpentTime = new TimeSpan(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks)).ToString("hh\\:mm\\:ss"),
                                                                })
                                                                .Take(10)
                                                                .OrderByDescending(c => c.SpentMoney)
                                                                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTopCustomerDto[]), new XmlRootAttribute("Customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}