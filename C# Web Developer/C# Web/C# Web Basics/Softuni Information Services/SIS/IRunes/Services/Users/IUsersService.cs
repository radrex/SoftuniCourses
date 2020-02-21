namespace IRunes.Services.Users
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);
        void RegisterUser(string username, string password, string email);
        bool UsernameExists(string username);
        bool EmailExists(string email);
        string GetUsername(string id);
    }
}
