namespace SIS.MvcFramework
{
    using SIS.HTTP;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute()
        {
        }

        public HttpGetAttribute(string url)
            : base(url)
        {
        }

        public override HttpMethodType Type => HttpMethodType.Get;
    }
}
