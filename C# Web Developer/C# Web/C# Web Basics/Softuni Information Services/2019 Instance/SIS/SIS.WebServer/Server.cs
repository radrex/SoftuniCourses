namespace SIS.WebServer
{
    using Routing.Contracts;

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    /// <summary>
    /// A wrapper class for the TCP connection. It uses a TcpListener to capture Client connections and then passes them to the ConnectionHandler, which processes them.
    /// </summary>
    public class Server
    {
        //--------------------------- CONSTANTS --------------------------
        private const string LocalhostIpAddress = "127.0.0.1";

        //---------------------------- FIELDS ----------------------------
        private readonly int port;
        private readonly TcpListener tcpListener;
        private readonly IServerRoutingTable serverRoutingTable;
        private bool isRunning;

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates a new server on localhost with the given port.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="serverRoutingTable"></param>
        public Server(int port, IServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);
            this.serverRoutingTable = serverRoutingTable;
        }

        //--------------------------- PUBLIC METHODS ----------------------------
        /// <summary>
        /// Starts the listening process. Should be asynchronous to ensure concurrent client functionality.
        /// </summary>
        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");

            while (this.isRunning)
            {
                Console.WriteLine("Waiting for client...");

                Socket client = this.tcpListener.AcceptSocketAsync().GetAwaiter().GetResult();
                Task.Run(() => Listen(client));
            }
        }

        //--------------------------- PRIVATE METHODS ---------------------------
        /// <summary>
        /// Deals with main processing of the client connection. Instantiates a <c>ConnectionHandler</c> for each client connection, 
        /// then client and routing table are passed to it, so that the Request can be processed.
        /// </summary>
        /// <param name="client">Client Socket</param>
        private async Task Listen(Socket client)
        {
            ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}
