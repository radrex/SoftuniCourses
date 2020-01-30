namespace SIS.HTTP.Requests.Contracts
{
    using Enums;
    using Headers.Contracts;
    using Cookies.Contracts;

    using System.Collections.Generic;

    /// <summary>
    /// Describes behavior of HTTP Request object.
    /// </summary>
    public interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookieCollection Cookies { get; }
        HttpRequestMethod RequestMethod { get; }
    }
}
