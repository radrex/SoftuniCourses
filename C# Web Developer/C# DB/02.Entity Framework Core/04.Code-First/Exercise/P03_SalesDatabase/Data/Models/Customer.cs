namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        //------------- Properties --------------
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }

        //------------- Collections -------------
        public ICollection<Sale> Sales => new HashSet<Sale>();
    }
}
