namespace SIS.HTTP.Headers.Contracts
{
    /// <summary>
    /// Interface for collection of HTTP headers, includes Add, Contains and Get methods.
    /// </summary>
    public interface IHttpHeaderCollection
    {
        void AddHeader(HttpHeader header);
        bool ContainsHeader(string key);
        HttpHeader GetHeader(string key);
    }
}
