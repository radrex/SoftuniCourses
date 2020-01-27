namespace SIS.HTTP.Extensions
{
    /// <summary>
    /// Extension methods for String.
    /// </summary>
    public static class StringExtensions
    {
        //--------------------------- METHODS ----------------------------
        /// <summary>
        /// Set first letter to Upper Case and all remaining letters to Lower Case.
        /// </summary>
        /// <param name="text">text for capitalization</param>
        /// <returns>Capitalized string</returns>
        public static string Capitalize(this string text) => char.ToUpper(text[0]) + text.Substring(1).ToLower();
    }
}
