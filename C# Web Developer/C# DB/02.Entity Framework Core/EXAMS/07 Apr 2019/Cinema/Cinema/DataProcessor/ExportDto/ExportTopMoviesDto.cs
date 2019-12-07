namespace Cinema.DataProcessor.ExportDto
{
    public class ExportTopMoviesDto
    {
        public string MovieName { get; set; }
        public string Rating { get; set; }
        public string TotalIncomes { get; set; }
        public ExportCustomerBalanceDto[] Customers { get; set; }
    }

    public class ExportCustomerBalanceDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Balance { get; set; }
    }
}
