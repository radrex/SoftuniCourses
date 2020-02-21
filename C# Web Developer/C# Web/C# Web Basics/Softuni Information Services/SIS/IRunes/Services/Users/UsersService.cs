namespace IRunes.Services.Users
{
    using System.Text;
    using IRunes.Data;
    using System.Security.Cryptography;
    using System.Linq;
    using IRunes.Models;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool UsernameExists(string username) => this.db.Users.Any(x => x.Username == username);
        public bool EmailExists(string email) => this.db.Users.Any(x => x.Email == email);
        public string GetUsername(string id) => this.db.Users.Where(x => x.Id == id).Select(x => x.Username).FirstOrDefault();
        public string GetUserId(string username, string password)
        {
            string hashedPassword = this.Hash(password);
            return this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword)?.Id;
        }

        public void RegisterUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username, 
                Password = this.Hash(password),
                Email = email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
