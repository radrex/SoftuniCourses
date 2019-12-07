namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            //------------------------------------------ WITH LINQ --------------------------------------------
            //StringBuilder sb = new StringBuilder();
            //Movie[] movies = JsonConvert.DeserializeObject<Movie[]>(jsonString).Where(m => IsValid(m)).ToArray(); //instead of DTO's, without foreach

            //------------------------------------------ NO DTO ----------------------------------------------
            StringBuilder sb = new StringBuilder();
            Movie[] moviesArr = JsonConvert.DeserializeObject<Movie[]>(jsonString);             //instead of DTO's, but with foreach

            List<Movie> movies = new List<Movie>();
            foreach (Movie movie in moviesArr)
            {
                if (IsValid(movie))
                {
                    Movie currentMovie = new Movie
                    {
                        Title = movie.Title,
                        Genre = movie.Genre,
                        Duration = movie.Duration,
                        Rating = movie.Rating,
                        Director = movie.Director,
                    };
                    movies.Add(movie);
                    sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

            //------------------------------------------ WITH DTO --------------------------------------------
            //StringBuilder sb = new StringBuilder();
            //ImportMovieDto[] movietDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            //List<Movie> movies = new List<Movie>();
            //foreach (ImportMovieDto dto in movietDtos)
            //{
            //    if (IsValid(dto))
            //    {
            //        Movie movie = new Movie
            //        {
            //            Title = dto.Title,
            //            Genre = dto.Genre,
            //            Duration = dto.Duration,
            //            Rating = dto.Rating,
            //            Director = dto.Director,
            //        };
            //        movies.Add(movie);
            //        sb.AppendLine(String.Format(SuccessfulImportMovie, dto.Title, dto.Genre, dto.Rating.ToString("F2")));
            //    }
            //    else
            //    {
            //        sb.AppendLine(ErrorMessage);
            //    }
            //}

            //context.Movies.AddRange(movies);
            //context.SaveChanges();
            //return sb.ToString().TrimEnd();
        }
        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportHallSeatDto[] hallDtos = JsonConvert.DeserializeObject<ImportHallSeatDto[]>(jsonString);

            foreach (ImportHallSeatDto dto in hallDtos)
            {
                if (IsValid(dto))
                {
                    //--- ADD HALL ---
                    Hall currentHall = new Hall
                    {
                        Name = dto.Name,
                        Is4Dx = dto.Is4Dx,
                        Is3D = dto.Is3D,
                    };
                    context.Halls.Add(currentHall);
                    context.SaveChanges();

                    //--- ADD SEATS ---
                    List<Seat> seats = new List<Seat>();
                    for (int i = 0; i < dto.Seats; i++)
                    {
                        Seat seat = new Seat();
                        seat.HallId = currentHall.Id;

                        seats.Add(seat);
                    }

                    context.Seats.AddRange(seats);
                    context.SaveChanges();

                    if (currentHall.Is3D && currentHall.Is4Dx)
                    {
                        sb.AppendLine(String.Format(SuccessfulImportHallSeat, currentHall.Name, "4Dx/3D", currentHall.Seats.Count));
                    }
                    else
                    {
                        if (currentHall.Is3D)
                        {
                            sb.AppendLine(String.Format(SuccessfulImportHallSeat, currentHall.Name, "3D", currentHall.Seats.Count));
                        }
                        else if (currentHall.Is4Dx)
                        {
                            sb.AppendLine(String.Format(SuccessfulImportHallSeat, currentHall.Name, "4Dx", currentHall.Seats.Count));
                        }
                        else
                        {
                            sb.AppendLine(String.Format(SuccessfulImportHallSeat, currentHall.Name, "Normal", currentHall.Seats.Count));
                        }
                    }
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            ImportProjectionDto[] projectionDtos;
            using (var reader = new StringReader(xmlString))
            {
                projectionDtos = (xmlSerializer.Deserialize(reader) as ImportProjectionDto[]);
                //.Where(p => context.Movies.Any(m => m.Id == p.MovieId) && context.Halls.Any(h => h.Id == p.HallId)).ToArray();
                // IsMovieIdValid and IsHallIdValid METHODS
            }

            foreach (ImportProjectionDto dto in projectionDtos)
            {
                if (IsValid(dto) && IsMovieIdValid(context, dto.MovieId) && IsHallIdValid(context, dto.HallId))
                {
                    Projection projection = new Projection()
                    {
                        MovieId = dto.MovieId,
                        HallId = dto.HallId,
                        DateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    };

                    context.Projections.Add(projection);

                    var dateTimeResult = projection.DateTime.ToString("MM/dd/yyyy");
                    sb.AppendLine(String.Format(SuccessfulImportProjection, projection.Movie.Title, dateTimeResult));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketsDto[]), new XmlRootAttribute("Customers"));

            ImportCustomerTicketsDto[] customerTicketDtos;
            using (var reader = new StringReader(xmlString))
            {
                customerTicketDtos = (xmlSerializer.Deserialize(reader) as ImportCustomerTicketsDto[]);
                //.Where(p => context.Movies.Any(m => m.Id == p.MovieId) && context.Halls.Any(h => h.Id == p.HallId)).ToArray();
                // IsMovieIdValid and IsHallIdValid METHODS
            }

            foreach (ImportCustomerTicketsDto dto in customerTicketDtos)
            {
                if (IsValid(dto))
                {
                    Customer customer = new Customer()
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Age = dto.Age,
                        Balance = dto.Balance,
                    };

                    context.Customers.Add(customer);

                    List<Ticket> tickets = new List<Ticket>();
                    foreach (ImportTicketDto ticketDto in dto.Tickets)
                    {
                        if (IsValid(ticketDto))
                        {
                            Ticket ticket = new Ticket
                            {
                                ProjectionId = ticketDto.ProjectionId,
                                Price = ticketDto.Price,
                            };

                            ticket.Customer = customer; // ASSIGN CUSTOMER ON TICKET
                            tickets.Add(ticket); // ADD TICKET
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    context.Tickets.AddRange(tickets);
                    context.SaveChanges();
                    
                    sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, tickets.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            //context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        //-----------------------------------------------------------------------------------
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }
        private static bool IsHallIdValid(CinemaContext context, int hallId)
        {
            return context.Halls.Any(h => h.Id == hallId);
        }

        private static bool IsMovieIdValid(CinemaContext context, int movieId)
        {
            return context.Movies.Any(m => m.Id == movieId);
        }
    }
}