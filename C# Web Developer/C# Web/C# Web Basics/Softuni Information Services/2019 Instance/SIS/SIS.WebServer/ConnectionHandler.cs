namespace SIS.WebServer
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    using Results;
    using Routing.Contracts;

    using System;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// A client connection processor. It receives the connection, extracts the request string data from it, processes it using the routing table,
    /// and then sends back the Response in a byte format, throughout the TCP link.
    /// </summary>
    public class ConnectionHandler
    {
        //---------------------------- FIELDS ----------------------------
        private readonly Socket client;
        private readonly IServerRoutingTable serverRoutingTable;

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Initializes the socket (wrapper object for client connection) and the routing table.
        /// </summary>
        /// <param name="client">Client Socket</param>
        /// <param name="serverRoutingTable">Server Routing Table</param>
        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        //--------------------------- PUBLIC METHODS ----------------------------
        /// <summary>
        /// Contains the main functionality of the class. It uses the other methods to read the request, handle it, generate a response, send it to the client, and finally close the connection.
        /// </summary>
        public void ProcessRequest()
        {
            try
            {
                IHttpRequest httpRequest = this.ReadRequest();

                if (httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");
                    IHttpResponse httpResponse = this.HandleRequest(httpRequest);
                    this.PrepareResponse(httpResponse);
                }
            }
            catch (BadRequestException ex)
            {
                this.PrepareResponse(new TextResult(ex.ToString(), HttpResponseStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                this.PrepareResponse(new TextResult(ex.ToString(), HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        //--------------------------- PRIVATE METHODS ---------------------------
        /// <summary>
        /// Reads the byte data from the client connection, extracts the request string data from it, and then maps it to a <c>HttpRequest</c> object.
        /// Requests are limited to 1024 bytes.
        /// </summary>
        /// <returns>HTTP Request interface</returns>
        private IHttpRequest ReadRequest()
        {
            StringBuilder result = new StringBuilder();
            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int readBytes = this.client.Receive(data.Array, SocketFlags.None);
                if (readBytes == 0)
                {
                    break;
                }

                string bytesAsString = Encoding.UTF8.GetString(data.Array, 0, readBytes);
                result.Append(bytesAsString);

                if (readBytes < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        /// <summary>
        /// Checks if the routing table has a handler for the given Request, using the Request's Method and Path.
        /// </summary>
        /// <param name="httpRequest">HTTP Request</param>
        /// <returns>HTTP Response interface</returns>
        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Contains(httpRequest.RequestMethod, httpRequest.Path))
            {
                return new TextResult($"Route with method {httpRequest.RequestMethod} and path \"{httpRequest.Path}\" not found.", HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Get(httpRequest.RequestMethod, httpRequest.Path).Invoke(httpRequest);
        }

        /// <summary>
        /// Extracts the byte data from the Response and sends it to the client.
        /// </summary>
        /// <param name="httpResponse">HTTP Response</param>
        private void PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();
            this.client.Send(byteSegments, SocketFlags.None);
        }
    }
}
