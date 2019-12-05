namespace ProductShop.Dtos.Export
{
    public class UserSoldProductsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BuyerProductsDto[] SoldProducts { get; set; }
    }

    public class BuyerProductsDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
    }
}
