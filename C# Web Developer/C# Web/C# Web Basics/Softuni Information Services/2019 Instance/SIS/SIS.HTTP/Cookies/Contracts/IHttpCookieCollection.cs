namespace SIS.HTTP.Cookies.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines HttpCookieCollection functionality.
    /// </summary>
    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        /// <summary>
        /// Adds the cookie to the HttpCookie collection.
        /// </summary>
        /// <param name="cookie">HttpCookie</param>
        void AddCookie(HttpCookie cookie);

        /// <summary>
        /// Returns a boolean result, on whether the given key is contained in the HttpCookie collection.
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <returns>True or False</returns>
        bool ContainsCookie(string key);

        /// <summary>
        /// Extracts the cookie with the given key from the HttpCookie collection and returns it.
        /// </summary>
        /// <param name="key">Cookie key</param>
        /// <returns>HttpCookie</returns>
        HttpCookie GetCookie(string key);

        /// <summary>
        /// Returns a boolean result, on whether there are ANY cookies in the HttpCookie collection.
        /// </summary>
        /// <returns>True or False</returns>
        bool HasCookies();
    }
}
