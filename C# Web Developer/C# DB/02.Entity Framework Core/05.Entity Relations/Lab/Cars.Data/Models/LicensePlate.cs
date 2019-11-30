namespace Cars.Data.Models
{
    public class LicensePlate
    {
        //--------------- Properties ----------------
        public int Id { get; set; }
        public string Number { get; set; }

        //-------- Car -------- [FK]
        public int? CarId { get; set; }
        public Car Car { get; set; }
    }
}
