namespace SIS.HTTP
{
    /// <summary>
    /// HTTP Response Status Codes.
    /// </summary>
    public enum HttpResponseStatusCode
    {
        Ok = 200,
        Created = 201,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        TemporaryRedirect = 307,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501,
    }
}