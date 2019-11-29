namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Store
    {
        //------------- Properties --------------
        public int StoreId { get; set; }
        public string Name { get; set; }

        //------------- Collections -------------
        public ICollection<Sale> Sales => new HashSet<Sale>();
    }
}
