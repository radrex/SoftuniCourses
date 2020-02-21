namespace SIS.HTTP.Response
{
    /// <summary>
    /// Represents an Redirect Response with properties for the <c>Response Status Line</c>, <c>Response Headers</c> and <c>Response Body</c>.
    /// </summary>
    public class RedirectResponse : HttpResponse
    {
        /// <summary>
        /// Initializes a new <see cref="RedirectResponse"/> class.
        /// </summary>
        /// <param name="newLocation">Location for redirect</param>
        public RedirectResponse(string newLocation)
        {
            this.Headers.Add(new Header("Location", newLocation));
            this.StatusCode = HttpResponseStatusCode.Found;
        }
    }
}
