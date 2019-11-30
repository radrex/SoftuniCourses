namespace Cars.Data.Models
{
    public class CarDealership
    {
        //------------- Properties --------------

        //----------- Car ------------ [FK]
        public int CarId { get; set; }
        public Car Car { get; set; }

        //-------- Dealership -------- [FK]
        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
    }
}
