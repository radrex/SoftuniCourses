namespace P04_HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal price, int days, Season season, Discount discount)
        {
            decimal total = (price * (int)season) * days;
            total -= total * (decimal)discount / 100;
            return total;
        }
    }
}
