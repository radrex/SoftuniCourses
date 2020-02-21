namespace SIS.HTTP.Response
{
    public class StatusCodeResponse : HttpResponse
    {
        public StatusCodeResponse(HttpResponseStatusCode code)
        {
            this.StatusCode = code;
        }
    }
}
