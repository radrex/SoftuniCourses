namespace SulsApp.Services
{
    using System.Text;
    using System.Security.Cryptography;
    using SulsApp.Models;
    using System.Linq;
    using SIS.MvcFramework;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void ChangePassword(string username, string newPassword)
        {
            User user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return;
            }

            user.Password = this.Hash(newPassword);
            this.db.SaveChanges();
        }

        public int CountUsers() => this.db.Users.Count();

        public void CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Email = email,
                Username = username,
                Password = this.Hash(password),
                Role = IdentityRole.User,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            string passwordHash = this.Hash(password);
            return this.db.Users.Where(x => x.Username == username && x.Password == passwordHash)
                                .Select(x => x.Id)
                                .FirstOrDefault();
        }

        public bool IsEmailUsed(string email) => this.db.Users.Any(x => x.Email == email);

        public bool IsUsernameUsed(string username) => this.db.Users.Any(x => x.Username == username);

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
