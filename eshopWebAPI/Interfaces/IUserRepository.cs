using eshopWebAPI.Models;

namespace eshopWebAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(int userId);

        bool UserExists(int userId);

        bool UserCreate(User createUser);
        bool Saved();
    }
}
