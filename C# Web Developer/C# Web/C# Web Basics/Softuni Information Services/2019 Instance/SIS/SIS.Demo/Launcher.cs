namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    using SIS.WebServer;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;
    using SIS.WebServer.Routing.Contracts;

    using Controllers;

    using System;
    using System.Globalization;
    using System.Text;
    using SIS.HTTP.Responses.Contracts;

    /// <summary>
    /// Holds the Main method, which instantiates a <c>Server</c> and configures it to handle requests using the <c>ServerRoutingTable</c>.
    /// </summary>
    public class Launcher
    {
        static void Main(string[] args)
        {
            /* TEST 1
                string request =
                    "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n" +
                    "Authorization: Basic 238482905\r\n" +
                    "Date: " + DateTime.Now + "\r\n" +
                    "Host: localhost:5000\r\n" +
                    "\r\n" +
                    "username=johndoe&password=123";

                HttpRequest httpRequest = new HttpRequest(request);
            */

            /* TEST 2
                HttpResponseStatusCode statusCode = HttpResponseStatusCode.Unauthorized;
                Console.WriteLine(statusCode);
            */

            /* TEST 3
                HttpResponse response = new HttpResponse(HttpResponseStatusCode.InternalServerError);
                response.AddHeader(new HttpHeader("Host", "localhost:5000"));
                response.AddHeader(new HttpHeader("Date", DateTime.Now.ToString(CultureInfo.InvariantCulture)));
                response.Content = Encoding.UTF8.GetBytes("<h1>Hello World!</h1>");
                Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));
            */

            /* TEST 4 -> http://localhost:8000/
                IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
                serverRoutingTable.Add(HttpRequestMethod.Get, "/", httpRequest =>
                {
                    return new HtmlResult("<h1>Hello World!</h1>", HttpResponseStatusCode.Ok);
                });

                Server server = new Server(8000, serverRoutingTable);
                server.Run();
            */

            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => (HttpResponse)new HomeController().Home(request));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }   
    }
}
