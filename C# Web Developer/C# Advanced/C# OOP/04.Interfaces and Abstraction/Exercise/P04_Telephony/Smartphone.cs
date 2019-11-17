namespace P04_Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : ICallable, IBrowseable
    {
        //----------- Constructors -------------
        public Smartphone()
        {

        }

        //------------- Methods ----------------
        public string Call(string number)
        {
            if (number.Any(x => !Char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }
    }
}
