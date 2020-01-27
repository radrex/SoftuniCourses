namespace SIS.HTTP.Extensions
{
    using Enums;
    /// <summary>
    /// Contains Extension Methods for HttpResponseStatusCode Enumeration.
    /// </summary>
    public static class HttpResponseStatusExtensions
    {
        /// <summary>
        /// Returns HTTP Status Code concatenated with Status Name
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns>Status code and Status name</returns>
        public static string GetStatusLine(this HttpResponseStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpResponseStatusCode.Ok: return "200 OK";
                case HttpResponseStatusCode.Created: return "201 Created";
                case HttpResponseStatusCode.Found: return "302 Found";
                case HttpResponseStatusCode.SeeOther: return "303 SeeOther";
                case HttpResponseStatusCode.BadRequest: return "400 BadRequest";
                case HttpResponseStatusCode.Unauthorized: return "401 Unauthorized";
                case HttpResponseStatusCode.Forbidden: return "403 Forbidden";
                case HttpResponseStatusCode.NotFound: return "404 NotFound";
                case HttpResponseStatusCode.InternalServerError: return "500 InternalServerError";
            }

            return null;
        }
    }
}
