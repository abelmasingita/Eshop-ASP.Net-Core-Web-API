using eshopWebAPI.Contracts;
using eshopWebAPI.Data;
using eshopWebAPI.Models;

namespace eshopWebAPI.Repositories
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(DataContext context) : base(context)
        {
        }
    }
}
