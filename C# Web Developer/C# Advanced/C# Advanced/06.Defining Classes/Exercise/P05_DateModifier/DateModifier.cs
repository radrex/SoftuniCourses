namespace P05_DateModifier
{
    using System;

    public class DateModifier
    {
        //-------------- Constructors --------------
        public DateModifier(string date1, string date2)
        {
            this.Date1 = DateTime.ParseExact(date1, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            this.Date2 = DateTime.ParseExact(date2, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        //--------------- Properties ---------------
        public DateTime Date1 { get; private set; }

        public DateTime Date2 { get; private set; }

        //---------------- Methods -----------------
        public int GetDaysDifference(string date1, string date2)
        {
            return Math.Abs((this.Date1.Date - this.Date2.Date).Days);
        }
    }
}
