using eshopWebAPI.Data;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

        public bool ProductCreate( Product createProduct)
        {
            _dataContext.Add(createProduct);
            return Saved();
        }

        public bool ProductDelete(Product deleteProduct)
        {
            _dataContext.Remove(deleteProduct);
            return Saved();
        }

        public bool ProductExists(int productId)
        {
            return _dataContext.Products.Any(p => p.Id == productId);
        }

        public bool ProductUpdate(Product updateProduct)
        {
            _dataContext.Update(updateProduct);
            return Saved();
        }

        public bool Saved()
        {
            var saved = _dataContext.SaveChanges();

            return saved > 0 ? true : false;    
        }
    }
}
