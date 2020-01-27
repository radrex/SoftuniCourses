namespace SIS.WebServer.Routing.Contracts
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    using System;

    /// <summary>
    /// Describes routing logic and server configuration.
    /// </summary>
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, HttpResponse> func);

        bool Contains(HttpRequestMethod requestMethod, string path);

        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path);
    }
}
