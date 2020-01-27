namespace SIS.HTTP.Common
{
    using System;

    /// <summary>
    /// Contains core validation methods.
    /// </summary>
    public class CoreValidator
    {
        //--------------------------- STATIC METHODS ----------------------------
        /// <summary>
        /// Checks object for Null, if so throws ArgumentNullException.
        /// </summary>
        public static void ThrowIfNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Checks text for NullOrEmpty, if so throws ArgumentException.
        /// </summary>
        public static void ThrowIfNullOrEmpty(string text, string name)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"{name} cannot be null or empty.", name);
            }
        }
    }
}
