using eshopWebAPI.Models;

namespace eshopWebAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();

        Product GetProductById(int productId);
        bool ProductExists(int productId);

        bool ProductCreate(Product createProduct);
        bool Saved();
    }
}
