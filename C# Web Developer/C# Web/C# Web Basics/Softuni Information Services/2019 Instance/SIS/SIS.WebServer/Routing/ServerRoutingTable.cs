namespace SIS.WebServer.Routing
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Common;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    using Routing.Contracts;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Holds routing logic and the configuration of the Server.
    /// </summary>
    public class ServerRoutingTable : IServerRoutingTable
    {
        //--------------------------- FIELDS -----------------------------
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> routingTable;

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates a Server Routing Table, that holds Routing Functions for specified Paths on Get, Post, Put and Delete HTTP Request Methods.
        /// </summary>
        public ServerRoutingTable()
        {
            this.routingTable = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>()
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
            };
        }

        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Adds routing function to path on that method in the Routing Table.
        /// </summary>
        /// <param name="method">HTTP Request Method</param>
        /// <param name="path">Specified Path</param>
        /// <param name="func">Routing Function</param>
        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, HttpResponse> func)
        {
            CoreValidator.ThrowIfNull(method, nameof(method));
            CoreValidator.ThrowIfNull(path, nameof(path));
            CoreValidator.ThrowIfNull(func, nameof(func));

            this.routingTable[method].Add(path, func);
        }

        /// <summary>
        /// Checks if Routing table contains specified HTTP Request Method and that the Request Method contains the specified path. If either of them is false, returns false.
        /// </summary>
        /// <param name="method">HTTP Request Method</param>
        /// <param name="path">Specified Path</param>
        /// <returns>True or False</returns>
        public bool Contains(HttpRequestMethod method, string path)
        {
            CoreValidator.ThrowIfNull(method, nameof(method));
            CoreValidator.ThrowIfNull(path, nameof(path));

            return this.routingTable.ContainsKey(method) && this.routingTable[method].ContainsKey(path);
        }

        /// <summary>
        /// Gets a Routing Function from the Routing Table.
        /// </summary>
        /// <param name="method">HTTP Request Method</param>
        /// <param name="path">Specified Path</param>
        /// <returns></returns>
        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod method, string path)
        {
            CoreValidator.ThrowIfNull(method, nameof(method));
            CoreValidator.ThrowIfNull(path, nameof(path));

            return this.routingTable[method][path];
        }
    }
}
