namespace P03_SalesDatabase.Data.Models
{
    using System;

    public class Sale
    {
        //------------- Properties --------------
        public int SaleId { get; set; }
        public DateTime Date { get; set; }

        //-------- Product -------- [FK]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //-------- Customer ------- [FK]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //-------- Store ---------- [FK]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
