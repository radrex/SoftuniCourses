namespace PetStore.Services.Models.Brand
{
    using Toy;
    using System.Collections.Generic;

    public class BrandWithToysServiceModel
    {
        public string Name { get; set; }
        public IEnumerable<ToyListingServiceModel> Toys { get; set; }
    }
}
