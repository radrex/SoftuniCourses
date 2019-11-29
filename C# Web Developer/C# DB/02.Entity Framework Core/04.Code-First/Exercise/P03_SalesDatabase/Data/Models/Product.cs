namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Product
    {
        //------------- Properties --------------
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } // For P04_ProductsMigration

        //------------- Collections -------------
        public ICollection<Sale> Sales => new HashSet<Sale>();
    }
}
