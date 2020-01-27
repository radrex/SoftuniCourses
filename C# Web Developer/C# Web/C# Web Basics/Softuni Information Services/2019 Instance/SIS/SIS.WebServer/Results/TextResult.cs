namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    using System.Text;

    /// <summary>
    /// Holds text contents, a simple plain text response. It has "Content-Type: text/plain" header.
    /// </summary>
    public class TextResult : HttpResponse
    {
        //------------------------- CONSTRUCTORS -------------------------
        public TextResult(string content, HttpResponseStatusCode responseStatusCode, string contentType = "text/plain; charset=utf-8")
            : base(responseStatusCode)
        {
            //TODO: Extract Headers as constants / remove magic strings
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode, string contentType = "text/plain; charset=utf-8")
            : base(responseStatusCode)
        {
            //TODO: Extract Headers as constants / remove magic strings
            this.Content = content;
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
        }
    }
}
