using eshopWebAPI.Data;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;

namespace eshopWebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Product GetProductById(int productId)
        {
            return _dataContext.Products.Where(p => p.Id == productId).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _dataContext.Products.ToList();
        }

        public bool ProductExists(int productId)
        {
            return _dataContext.Products.Any(p => p.Id == productId);
        }
    }
}
