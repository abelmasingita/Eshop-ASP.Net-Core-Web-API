using eshopWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eshopWebAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            AppUser appUser = new AppUser()
            {
                FirstName = "Abel",
                LastName = "Masingita",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Id = "1",
            };
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "admin12345");

            modelBuilder.Entity<AppUser>().HasData(appUser);


            modelBuilder.Entity<IdentityRole>().HasData(

               new IdentityRole
               {
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR",
                   Id = "d11a0d4e-338a-40cd-83e0-c600385c8a0a"
               },
              new IdentityRole
              {
                  Name = "User",
                  NormalizedName = "USER",
                  Id= "c79a2ce5-4f1a-46dc-adc1-3c10bca95d83"
              });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            
                new IdentityUserRole<string>()
                {
                    RoleId = "d11a0d4e-338a-40cd-83e0-c600385c8a0a",
                    UserId = "1"
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

                Id = "3",
                UserId = "1",
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
                 UserId = "1",
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
                 UserId = "1",
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
