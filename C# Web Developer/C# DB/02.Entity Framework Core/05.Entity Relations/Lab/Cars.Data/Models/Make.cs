namespace Cars.Data.Models
{
    using System.Collections.Generic;

    public class Make
    {
        //--------------- Properties ----------------
        public int Id { get; set; }
        public string Name { get; set; }

        //--------------- Collections ---------------
        //-------- Car -------- [FK]
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
