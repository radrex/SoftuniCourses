namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    using System.Text;

    /// <summary>
    /// Holds HTML contents, a simple HTML Response, with which we can return HTML pages or just simple message. It has "Content-Type: text/html" header.
    /// </summary>
    public class HtmlResult : HttpResponse
    {
        //------------------------- CONSTRUCTORS -------------------------
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            //TODO: Extract Headers as constants / remove magic strings
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset=utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
