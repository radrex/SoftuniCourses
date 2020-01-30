namespace SIS.HTTP.Requests
{
    using Enums;
    using Common;
    using Headers;
    using Exceptions;
    using Cookies;
    using Cookies.Contracts;
    using Headers.Contracts;
    using Requests.Contracts;

    using System.Collections.Generic;
    using System;
    using System.Linq;


    /// <summary>
    /// HTTP Request class containing methods and data for 1.HTTP Request line, 2.HTTP Request headers, 3.HTTP Request body.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates HTTP Request.
        /// </summary>
        /// <param name="requestString">HTTP Request string</param>
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>(); // BodyData
            this.QueryData = new Dictionary<string, object>(); // QueryString parameters (QueryStringData)
            this.Headers = new HttpHeaderCollection();  // Headers
            this.Cookies = new HttpCookieCollection();  // Cookies

            this.ParseRequest(requestString);

        }

        //-------------------------- PROPERTIES --------------------------
        /// <summary>
        /// HTTP Request Line Path (The first part, before "?" delimiter).
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// HTTP Request Line Resource URL.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Collection of KeyValuePair HTTP_Request_Body parameters.
        /// </summary>
        public Dictionary<string, object> FormData { get; }

        /// <summary>
        /// Collection of KeyValuePair HTTP_Request_Query_String parameters.
        /// </summary>
        public Dictionary<string, object> QueryData { get; }

        /// <summary>
        /// Collection of HTTP Request Headers.
        /// </summary>
        public IHttpHeaderCollection Headers { get; }

        /// <summary>
        /// HTTP Request Line Method.
        /// </summary>
        public HttpRequestMethod RequestMethod { get; private set; }

        /// <summary>
        /// HTTP cookie collection.
        /// </summary>
        public IHttpCookieCollection Cookies { get; }

        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Checks if "Request Line" parameters are exactly 3 and last parameter is "HTTP/1.1" protocol.
        /// </summary>
        /// <param name="requestLineParams">Array of "Request Line" parameters.</param>
        /// <returns>True or False</returns>
        private bool IsValidRequestLine(string[] requestLineParams) => requestLineParams.Length == 3 && requestLineParams[2] == GlobalConstants.HttpOneProtocolFragment;
        
        /// <summary>
        /// Checks if Request Query String is valid.
        /// </summary>
        /// <param name="queryString">Query String</param>
        /// <param name="queryParameters">Query string parameters</param>
        /// <returns>True or False</returns>
        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            CoreValidator.ThrowIfNull(queryString, nameof(queryString));

            return true; //TODO: Regex query string
        }

        /// <summary>
        /// Tries to parse and set the "RequestMethod" property out of the "Request Line" -> {RequestMethod} {ResourceUrl} {HTTP version}. If unsuccessfull throws BadRequestException.
        /// </summary>
        /// <param name="requestLineParams">Array of "Request Line" parameters.</param>
        private void ParseRequestMethod(string[] requestLineParams)
        {
            bool parseResult = Enum.TryParse<HttpRequestMethod>(requestLineParams[0], true, out HttpRequestMethod requestMethod);

            if (!parseResult)
            {
                throw new BadRequestException(String.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage, requestLineParams[0]));
            }
            this.RequestMethod = requestMethod;
        }

        /// <summary>
        /// Tries to parse and set the "Url" property out of the "Request Line" -> {RequestMethod} {ResourceUrl} {HTTP version}.
        /// </summary>
        /// <param name="requestLineParams">Array of "Request Line" parameters.</param>
        private void ParseRequestUrl(string[] requestLineParams) => this.Url = requestLineParams[1];

        /// <summary>
        /// Tries to parse and set the "Path" property out of the "Url" property.
        /// </summary>
        private void ParseRequestPath() => this.Path = this.Url.Split('?')[0];

        /// <summary>
        /// Traverses the HTTP Request Lines and returns only the headers from it.
        /// </summary>
        /// <param name="requestLines"></param>
        /// <returns>IEnumerable<string> of Headers</returns>
        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length - 1; i++)
            {
                if (!String.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        /// <summary>
        /// Parses the HTTP Request headers and adds them to the "Headers" collection property.
        /// </summary>
        /// <param name="requestHeaders">Array of "Request Headers"</param>
        private void ParseRequestHeaders(string[] requestHeaders)
        {
            requestHeaders.Select(h => h.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                          .ToList()
                          .ForEach(headerKvp => this.Headers.AddHeader(new HttpHeader(headerKvp[0], headerKvp[1])));
            //take only headers in string[]


            //TODO: check kvp's for ContainsKey ?

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        /// <summary>
        /// Parses the HTTP Request cookies and adds them to <c>HttpCookieCollection</c>.
        /// </summary>
        private void ParseRequestCookies()
        {
            if (this.Headers.ContainsHeader(HttpHeader.Cookie))
            {
                string value = this.Headers.GetHeader(HttpHeader.Cookie).Value;
                string[] unparsedCookies = value.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string unparsedCookie in unparsedCookies)
                {
                    string[] cookieKVP = unparsedCookie.Split(new[] { '=' }, 2);
                    HttpCookie httpCookie = new HttpCookie(cookieKVP[0], cookieKVP[1], false);

                    this.Cookies.AddCookie(httpCookie);
                }
            }
        }

        /// <summary>
        /// Checks if there is a Query String in the URL.
        /// </summary>
        /// <returns>True or False</returns>
        private bool HasQueryString() => this.Url.Split('?').Length > 1;

        /// <summary>
        /// Parses the "Query String Parameters" out of the "Url" property and adds them to the "QueryData" property collection/dictionary.
        /// </summary>
        private void ParseRequestQueryStringParameters()
        {
            if (this.HasQueryString())
            {
                this.Url.Split(new[] { '#', '?' })[1]
                        .Split('&')
                        .Select(queryStringParameter => queryStringParameter.Split('='))
                        .ToList() //TODO: check kvp's for ContainsKey ? Parse multiple parameters by name
                        .ForEach(queryStringParameterKvp => this.QueryData.Add(queryStringParameterKvp[0], queryStringParameterKvp[1]));
            }
        }

        /// <summary>
        /// Parses the "Request Body Parameters" out of the "Request Body" string and adds them to the "FormData" property collection/dictionary.
        /// </summary>
        /// <param name="requestBody">Request body string</param>
        private void ParseRequestFormDataParameters(string requestBody)
        {
            if (!String.IsNullOrEmpty(requestBody))
            {
                //TODO: Parse multiple parameters by name
                requestBody.Split('&')
                           .Select(queryStringParameter => queryStringParameter.Split('='))
                           .ToList() //TODO: check kvp's for ContainsKey ?
                           .ForEach(queryStringParameterKvp => this.FormData.Add(queryStringParameterKvp[0], queryStringParameterKvp[1]));

                // id=1%id=2 NOT GOOD
                // checklist, dropdown menu in html submitted with same name (Multiple selections) cars=opel&cars=bmw duplicate key exception
            }
        }

        /// <summary>
        /// Wrapper method for parsing "Request Query String" parameters and "Request Form/Body Data" parameters.
        /// </summary>
        /// <param name="requestBody">Request Body string</param>
        private void ParseRequestParameters(string requestBody)
        {
            this.ParseRequestQueryStringParameters();
            this.ParseRequestFormDataParameters(requestBody); //TODO: split
        }

        /// <summary>
        /// Wrapper method for parsing HTTP Request string.
        /// </summary>
        /// <param name="requestString">HTTP Request string</param>
        private void ParseRequest(string requestString)
        {
            string[] splitRequestString = requestString.Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            string[] requestLineParams = splitRequestString[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (!this.IsValidRequestLine(requestLineParams))
            {
                throw new BadRequestException();
            }

            //---- I ---- Parse HTTP Request line ----------
            this.ParseRequestMethod(requestLineParams);
            this.ParseRequestUrl(requestLineParams);
            this.ParseRequestPath();

            //---- II ---- Parse HTTP Request headers ------
            this.ParseRequestHeaders(this.ParsePlainRequestHeaders(splitRequestString).ToArray());
            this.ParseRequestCookies();

            //---- III ---- Parse HTTP Request body --------
            this.ParseRequestParameters(splitRequestString[splitRequestString.Length - 1]);
        }
    }
}
