namespace SIS.HTTP.Headers
{
    using Common;

    /// <summary>
    /// HTTP Header with 2 properties - Key(Header Name) and Value(Header Value).
    /// </summary>
    public class HttpHeader
    {
        //-------------------------- CONSTANTS ---------------------------
        public const string Cookie = "Cookie";

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates new instance for HttpHeader with key and value, throws ArgumentException if passed parameters are invalid.
        /// </summary>
        /// <param name="key">Header key</param>
        /// <param name="value">Header value</param>
        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        //-------------------------- PROPERTIES --------------------------
        /// <summary>
        /// Header's Name.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Header's Value.
        /// </summary>
        public string Value { get; }

        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Returns formatted header
        /// </summary>
        /// <returns>Header string</returns>
        public override string ToString() => $"{this.Key}: {this.Value}";
    }
}
