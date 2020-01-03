namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;

    using System;
    using System.Linq;

    public class BreedService : IBreedService
    {
        //----------------- Fields ------------------
        private readonly PetStoreDbContext context;

        //-------------- Constructors ---------------
        public BreedService(PetStoreDbContext context)
        {
            this.context = context;
        }

        //---------------- Methods ------------------
        public void Add(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Breed name cannot be null or whitespace!");
            }

            Breed breed = new Breed()
            {
                Name = name,
            };

            this.context.Breeds.Add(breed);
            this.context.SaveChanges();
        }

        public bool Exists(int breedId) => this.context.Breeds.Any(b => b.Id == breedId);
    }
}
