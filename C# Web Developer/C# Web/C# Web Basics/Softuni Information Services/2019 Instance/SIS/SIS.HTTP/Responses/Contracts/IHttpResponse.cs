namespace SIS.HTTP.Responses.Contracts
{
    using Enums;
    using Headers;
    using Headers.Contracts;

    /// <summary>
    /// Describes behavior of HTTP Response object.
    /// </summary>
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get; }
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        byte[] GetBytes();
    }
}
