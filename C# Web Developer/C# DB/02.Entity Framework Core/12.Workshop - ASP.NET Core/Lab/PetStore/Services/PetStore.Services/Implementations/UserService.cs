namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;

    using System.Linq;

    public class UserService : IUserService
    {
        //------------------ Fields -------------------
        private readonly PetStoreDbContext context;

        //--------------- Constructors ----------------
        public UserService(PetStoreDbContext context)
        {
            this.context = context;
        }

        //----------------- Methods -------------------
        public void Register(string name, string email)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool Exists(int userId)
        {
            return this.context.Users.Any(u => u.Id == userId);
        }
    }
}
