namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    /// <summary>
    /// Doesn't hold any content. It's only purpose is to redirect the client. It has location and predefined status -> "SeeOther".
    /// </summary>
    public class RedirectResult : HttpResponse
    {
        //------------------------- CONSTRUCTORS -------------------------
        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            //TODO: remove magic string
            this.Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
