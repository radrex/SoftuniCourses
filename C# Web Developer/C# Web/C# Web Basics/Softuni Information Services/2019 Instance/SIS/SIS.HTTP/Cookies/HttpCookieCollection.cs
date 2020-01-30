namespace SIS.HTTP.Cookies
{
    using Common;
    using Cookies.Contracts;

    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        //--------------------------- FIELDS -----------------------------
        private readonly Dictionary<string, HttpCookie> httpCookies;

        //------------------------- CONSTRUCTORS -------------------------
        /// <summary>
        /// Creates a new <c>HttpCookieCollection</c>.
        /// </summary>
        public HttpCookieCollection()
        {
            this.httpCookies = new Dictionary<string, HttpCookie>();
        }

        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Adds the cookie to the HttpCookie collection.
        /// </summary>
        /// <param name="httpCookie"><c>HttpCookie</c></param>
        public void AddCookie(HttpCookie httpCookie)
        {
            CoreValidator.ThrowIfNull(httpCookie, nameof(httpCookie));
            this.httpCookies.Add(httpCookie.Key, httpCookie);
        }

        /// <summary>
        /// Returns a boolean result, on whether the given key is contained in the HttpCookie collection.
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <returns>True or False</returns>
        public bool ContainsCookie(string key) 
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.httpCookies.ContainsKey(key);
        }

        /// <summary>
        /// Extracts the cookie with the given key from the HttpCookie collection and returns it.
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <returns>Http Cookie</returns>
        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.httpCookies[key];
        }

        /// <summary>
        /// Returns a boolean result, on whether there are ANY cookies in the HttpCookie collection.
        /// </summary>
        /// <returns>True or False</returns>
        public bool HasCookies() => this.httpCookies.Count != 0;

        /// <summary>
        /// Formats the cookies in Web-Ready format.
        /// </summary>
        /// <returns>Formatted cookies</returns>
        /// 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (HttpCookie cookie in this.httpCookies.Values)
            {
                sb.Append($"Set-Cookie: {cookie}").Append(GlobalConstants.HttpNewLine);
            }

            return sb.ToString();
        }

        public IEnumerator<HttpCookie> GetEnumerator() => this.httpCookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
