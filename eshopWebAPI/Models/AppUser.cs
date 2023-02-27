using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eshopWebAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
