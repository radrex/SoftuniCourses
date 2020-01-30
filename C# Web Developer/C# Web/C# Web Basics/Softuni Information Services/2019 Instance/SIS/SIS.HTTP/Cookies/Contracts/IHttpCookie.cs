namespace SIS.HTTP.Cookies.Contracts
{
    using System;

    /// <summary>
    /// Describes <c>HttpCookie</c> functionality.
    /// </summary>
    public interface IHttpCookie
    {
        /// <summary>
        /// Cookie key.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Cookie value/content.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Cookie expiration date.
        /// </summary>
        DateTime Expires { get; }

        /// <summary>
        /// Cookie path.
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Define if the cookie is freshly created.
        /// </summary>
        bool IsNew { get; }

        /// <summary>
        /// Define if the cookie has <c>HttpOnly</c> flag.
        /// </summary>
        bool HttpOnly { get; set; }

        /// <summary>
        /// Delete cookie.
        /// </summary>
        void Delete();
    }
}
