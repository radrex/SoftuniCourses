namespace SIS.HTTP.Responses.Contracts
{
    using Enums;
    using Headers;
    using Cookies;
    using Headers.Contracts;
    using Cookies.Contracts;

    /// <summary>
    /// Describes behavior of HTTP Response object.
    /// </summary>
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookieCollection Cookies { get; }
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        void AddCookie(HttpCookie cookie);
        byte[] GetBytes();
    }
}
