namespace SIS.HTTP.Responses
{
    using Enums;
    using Common;
    using Headers;
    using Extensions;
    using Headers.Contracts;
    using Responses.Contracts;

    using System.Text;

    /// <summary>
    /// HTTP Response class which holds the response's StatusCode, Headers and Content.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates HTTP Response.
        /// </summary>
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }

        /// <summary>
        /// Creates HTTP Response and sets the StatusCode to the passed one if valid.
        /// </summary>
        /// <param name="statusCode">HTTP Response Status Code</param>
        public HttpResponse(HttpResponseStatusCode statusCode) : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        //-------------------------- PROPERTIES --------------------------
        /// <summary>
        /// HTTP Response Status Code.
        /// </summary>
        public HttpResponseStatusCode StatusCode { get; set; }

        /// <summary>
        /// Collection of HTTP Response headers.
        /// </summary>
        public IHttpHeaderCollection Headers { get; }

        /// <summary>
        /// HTTP Response body as byte[] array.
        /// </summary>
        public byte[] Content { get; set; }

        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Adds passed HTTP header to collection if valid.
        /// </summary>
        /// <param name="header">HTTP Header</param>
        public void AddHeader(HttpHeader header)
        {
            this.Headers.AddHeader(header);
        }

        /// <summary>
        /// Returns the whole HTTP Response as byte[] array.
        /// </summary>
        /// <returns>Array of bytes</returns>
        public byte[] GetBytes()
        {
            //return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray(); with LINQ but way way slower than looping...

            byte[] httpResponseWithoutBody = Encoding.UTF8.GetBytes(this.ToString());
            byte[] httpResponseWithBody = new byte[httpResponseWithoutBody.Length + this.Content.Length];

            for (int i = 0; i < httpResponseWithoutBody.Length; i++)
            {
                httpResponseWithBody[i] = httpResponseWithoutBody[i];
            }

            for (int i = 0; i < httpResponseWithBody.Length - httpResponseWithoutBody.Length; i++)
            {
                httpResponseWithBody[i + httpResponseWithoutBody.Length] = this.Content[i];
            }

            return httpResponseWithBody;
        }

        /// <summary>
        /// Returns formatted HTTP Response.
        /// </summary>
        /// <returns>HTTP Response string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}")
              .Append(GlobalConstants.HttpNewLine)
              .Append(this.Headers)
              .Append(GlobalConstants.HttpNewLine);

            sb.Append(GlobalConstants.HttpNewLine);

            return sb.ToString();
        }
    }
}
