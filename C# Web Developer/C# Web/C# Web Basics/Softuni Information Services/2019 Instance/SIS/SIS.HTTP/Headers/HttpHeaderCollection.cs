namespace SIS.HTTP.Headers
{
    using Common;
    using Headers.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Collection of HTTP headers, includes Add, Contains, Get methods and overridden ToString.
    /// </summary>
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        //--------------------------- FIELDS -----------------------------
        private readonly Dictionary<string, HttpHeader> headers;

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates HttpHeaderCollection in the form of a Dictionary<string, HttpHeader>();
        /// </summary>
        public HttpHeaderCollection() => this.headers = new Dictionary<string, HttpHeader>();


        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Adds header to collection.
        /// </summary>
        public void AddHeader(HttpHeader header)
        {
            if (!this.ContainsHeader(header.Key))
            {
                this.headers.Add(header.Key, header);
            }
        }

        /// <summary>
        /// Checks if collection contains passed header key.
        /// </summary>
        /// <param name="key">Header key</param>
        /// <returns>True or False</returns>
        public bool ContainsHeader(string key) => this.headers.ContainsKey(key);

        /// <summary>
        /// Searches collection for specified header by it's key.
        /// </summary>
        /// <param name="key">Header's key</param>
        /// <returns>HttpHeader or null</returns>
        public HttpHeader GetHeader(string key) => this.headers.FirstOrDefault(h => h.Key == key).Value;

        /// <summary>
        /// Returns a string of formatted headers.
        /// </summary>
        /// <returns>Headers string</returns>
        public override string ToString() => string.Join(GlobalConstants.HttpNewLine, this.headers.Values.Select(header => header.ToString()));
    }
}
