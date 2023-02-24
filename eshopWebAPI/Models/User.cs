using System.ComponentModel.DataAnnotations;

namespace eshopWebAPI.Models
{
    public class User
    {
        [Key]
        public string? Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
