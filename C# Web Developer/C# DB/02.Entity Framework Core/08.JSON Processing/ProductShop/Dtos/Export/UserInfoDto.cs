namespace ProductShop.Dtos.Export
{
    public class UserInfoDto
    {
        public int UsersCount { get; set; }
        public UserDetailsDto[] Users { get; set; }
    }

    public class UserDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public SoldProductsDto SoldProducts { get; set; }
    }

    public class SoldProductsDto
    {
        public int Count { get; set; }
        public ProductDetailsDto[] Products { get; set; }
    }

    public class ProductDetailsDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
