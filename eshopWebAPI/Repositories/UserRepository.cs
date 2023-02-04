using eshopWebAPI.Data;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;

namespace eshopWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public User GetUser(int userId)
        {
            return _dataContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _dataContext.Users.ToList();
        }

        public bool UserExists(int userId)
        {
            return _dataContext.Users.Any(u => u.Id == userId);
        }
    }
}
