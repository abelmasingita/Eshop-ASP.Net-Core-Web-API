using eshopWebAPI.Data;
using eshopWebAPI.Models;

namespace eshopWebAPI.Seed
{
    public class Seeder
    {
        private readonly DataContext _context;

        public Seeder(DataContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (!_context.Products.Any())
            {
                _context.Users.Add(new User { Name = "Abel Masingita", Email = "abelmasingita9@gmail.com", Password = "2196411223365441", Phone = "0742261505", Address = "Abel Masingita", IsAdmin=true, IsDeleted=false});
                _context.Users.Add(new User { Name = "Abel Hlongwani", Email = "abelmasingita910@gmail.com", Password = "2196411223365442", Phone = "0742261505", Address = "Abel Masingita", IsAdmin = true, IsDeleted = false });
                _context.Users.Add(new User { Name = "Abel Matimba", Email = "hlongwaniab@gmail.com", Password = "2196411223365443", Phone = "0742261505", Address = "Abel Masingita", IsAdmin = true, IsDeleted = false });

                _context.Products.Add(new Product {Name= "Batho SKR", Description="Walk your journey", Price=100.23, Rating=5.2, NumReviews=5,CountInStock=10,Brand="Batho", Category="Sneaker Men" });
                _context.Products.Add(new Product { Name = "Drip SKR", Description = "Walk your journey", Price = 100.23, Rating = 5.2, NumReviews = 5, CountInStock = 10, Brand = "Batho", Category = "Sneaker Men" });
                _context.Products.Add(new Product { Name = "Vaya", Description = "Walk your journey", Price = 100.23, Rating = 5.2, NumReviews = 5, CountInStock = 10, Brand = "Batho", Category = "Sneaker Men" });

                _context.SaveChanges(); 
            }
        }
    }
}
