namespace SIS.HTTP.Common
{
    /// <summary>
    /// Contains HTTP Global constants like - NewLine, HTTP protocol version etc. 
    /// </summary>
    public static class GlobalConstants
    {
        public const string HttpOneProtocolFragment = "HTTP/1.1";
        public const string HostHeaderKey = "Host";
        public const string HttpNewLine = "\r\n";
        public const string UnsupportedHttpMethodExceptionMessage = "The HTTP method - {0} is not supported.";
    }
}
