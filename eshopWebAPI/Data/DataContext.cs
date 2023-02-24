using eshopWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eshopWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     FirstName = "Abel",
                     LastName = "Masingita",
                     Id = "1",
                 }, new User
                 {
                     FirstName = "Hlongwani",
                     LastName = "Masingita",
                     Id = "2",
                 }, new User
                 {
                     FirstName = "Masingita",
                     LastName = "Masingita",
                     Id = "3",
                 }
                );

            modelBuilder.Entity<Product>().HasData(
             new Product
             {

                 Id = "1",
                 UserId = "1",
                 Name = "All Star",
                 Description = "Converse",
                 Price = 100,
                 Rating = 5,
                 NumReviews = 4,
                 CountInStock = 5,
                 Brand = "Nike",
                 Category = "Men",
                 Image = ""

             },
            new Product
            {

                Id = "2",
                UserId = "2",
                Name = "All Star",
                Description = "Converse",
                Price = 100,
                Rating = 5,
                NumReviews = 4,
                CountInStock = 5,
                Brand = "Nike",
                Category = "Men",
                Image = ""

            },
            new Product
            {

                Id = "3",
                UserId = "3",
                Name = "All Star",
                Description = "Converse",
                Price = 100,
                Rating = 5,
                NumReviews = 4,
                CountInStock = 5,
                Brand = "Nike",
                Category = "Men",
                Image = "",

            }
            );

            modelBuilder.Entity<Order>().HasData(
             new Order
             {

                 Id = "1",
                 UserId = "1",
                 totalPrice = 100,
                 isDelivered = false,   
                 isPaid = true,
                 deliveredAt = DateTime.Now,
                 paidAt = DateTime.Now,
                 paymentMethod = "PayPal",
                 shippingPrice = 100,
                 taxPrice = 100,
                 paymentResult ="Success"

             }, new Order
             {

                 Id = "2",
                 UserId = "2",
                 totalPrice = 100,
                 isDelivered = false,
                 isPaid = true,
                 deliveredAt = DateTime.Now,
                 paidAt = DateTime.Now,
                 paymentMethod = "PayPal",
                 shippingPrice = 100,
                 taxPrice = 100,
                 paymentResult = "Success"

             }, new Order
             {

                 Id = "3",
                 UserId = "3",
                 totalPrice = 100,
                 isDelivered = false,
                 isPaid = true,
                 deliveredAt = DateTime.Now,
                 paidAt = DateTime.Now,
                 paymentMethod = "PayPal",
                 shippingPrice = 100,
                 taxPrice = 100,
                 paymentResult = "Success"

             });
        }
    }
}
