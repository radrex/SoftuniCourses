namespace SIS.HTTP
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an HTTP Request with properties for the <c>Request Line</c>, <c>Request Headers</c> and <c>Request Body</c>.
    /// </summary>
    public class HttpRequest
    {
        //------------- CONSTRUCTORS -------------
        /// <summary>
        /// Initializes a new <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="httpRequestAsString">HTTP Request string</param>
        public HttpRequest(string httpRequestAsString) //TODO: Extract HttpRequestParser that returns HttpRequest, and then pass it in HttpRequest constructor. Use yield return for PART II - Headers.
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            string[] lines = httpRequestAsString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            //---------------- PART I --> REQUEST LINE --------------------------
            string httpRequestLine = lines[0];
            string[] httpRequestLineParameters = httpRequestLine.Split(' ');

            if (httpRequestLineParameters.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header request line.");
            }

            string httpMethod = httpRequestLineParameters[0];

            //Enum.TryParse(httpMethod, out HttpMethodType type);
            this.Method = httpMethod switch
            {
                "GET"    =>   HttpMethodType.Get,
                "POST"   =>   HttpMethodType.Post,
                "PUT"    =>   HttpMethodType.Put,
                "DELETE" =>   HttpMethodType.Delete,
                _        =>   HttpMethodType.Unknown,
            };

            this.Path = httpRequestLineParameters[1];

            string httpVersion = httpRequestLineParameters[2];
            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.Http10,
                "HTTP/1.1" => HttpVersionType.Http11,
                "HTTP/2.0" => HttpVersionType.Http20,
                _          => HttpVersionType.Http11,
            };

            //---------------- PART II --> REQUEST HEADERS ----------------------
            bool isInHeader = true;
            StringBuilder bodyBuilder = new StringBuilder();
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (String.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                    continue;
                }

                if (isInHeader)
                {
                    string[] headerParts = line.Split(new string[] { ": " }, 2, StringSplitOptions.None);
                    if (headerParts.Length != 2)
                    {
                        throw new HttpServerException($"Invalid header: {line}");
                    }

                    Header header = new Header(headerParts[0], headerParts[1]);
                    this.Headers.Add(header);

                    if (headerParts[0] == "Cookie") // If we get a Cookie from the request header
                    {
                        string cookiesAsString = headerParts[1];
                        string[] cookies = cookiesAsString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string cookieAsString in cookies)
                        {
                            string[] cookieParts = cookiesAsString.Split(new char[] { '='}, 2);
                            if (cookieParts.Length == 2)
                            {
                                this.Cookies.Add(new Cookie(cookieParts[0], cookieParts[1]));
                            }
                        }
                    }
                }
                //---------------- PART III --> REQUEST BODY ------------------------
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }
        }

        //-------------- PROPERTIES --------------
        /// <summary>
        /// HTTP Request line Method.
        /// </summary>
        public HttpMethodType Method { get; set; }

        /// <summary>
        /// HTTP Request line Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// HTTP Request line Version.
        /// </summary>
        public HttpVersionType Version { get; set; }

        /// <summary>
        /// Collection of HTTP Request Headers.
        /// </summary>
        public IList<Header> Headers { get; set; }

        /// <summary>
        /// Collection of HTTP Request Cookies.
        /// </summary>
        public IList<Cookie> Cookies { get; set; }

        /// <summary>
        /// HTTP Request Body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> SessionData { get; set; }
    }
}
