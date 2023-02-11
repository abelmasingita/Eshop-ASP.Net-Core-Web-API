using eshopWebAPI.Data;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;

namespace eshopWebAPI.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
