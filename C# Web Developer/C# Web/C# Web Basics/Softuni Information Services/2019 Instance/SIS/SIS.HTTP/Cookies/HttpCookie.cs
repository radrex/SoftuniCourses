namespace SIS.HTTP.Cookies
{
    using Common;
    using Cookies.Contracts;

    using System;
    using System.Text;

    /// <summary>
    /// HttpCookie class containing information about the cookie like cookie key, cookie value, cookie path etc.
    /// </summary>
    public class HttpCookie : IHttpCookie
    {
        //-------------------------- CONSTANTS ---------------------------
        private const int HttpCookieDefaultExpirationDays = 3;
        private const string HttpCookieDefaultPath = "/";

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Create a new <c>HttpCookie</c>.
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <param name="value">Cookie value/content</param>
        /// <param name="expires">Cookie expiration days</param>
        /// <param name="path">Cookie path</param>
        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationDays, string path = HttpCookieDefaultPath)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Path = path;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        /// <summary>
        /// Create a new <c>HttpCookie</c>.
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <param name="value">Cookie value/content</param>
        /// <param name="isNew">Cookie existence</param>
        /// <param name="expires">Cookie expiration days</param>
        /// <param name="path">Cookie path</param>
        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationDays, string path = HttpCookieDefaultPath)
            : this(key, value, expires, path)
        {
            this.IsNew = IsNew;
        }

        //-------------------------- PROPERTIES --------------------------
        /// <summary>
        /// The Key/Name of the cookie.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The Value/Content of the cookie.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Expiration time of the cookie.
        /// </summary>
        public DateTime Expires { get; private set; }

        /// <summary>
        /// Default path of the cookie.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Boolean, used to define, if the cookie is freshly created.
        /// </summary>
        public bool IsNew { get; }

        /// <summary>
        /// Boolean, representing if the cookie has <c>HttpOnly</c> flag, by default true.
        /// </summary>
        public bool HttpOnly { get; set; } = true;

        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Deletes the cookie.
        /// </summary>
        public void Delete()
        {
            // Tells the browser that the cookie expires yesterday, so the browser deletes it.
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        /// <summary>
        /// Formats the cookie parameters in Web-ready format;
        /// </summary>
        /// <returns>Formatted cookie string.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Key}={this.Value}; Expires={this.Expires:R}");

            if (this.HttpOnly)
            {
                sb.Append("; HttpOnly");
            }

            sb.Append($"; Path={this.Path}");

            return sb.ToString();
        }
    }
}
