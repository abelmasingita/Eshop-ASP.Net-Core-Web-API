using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eshopWebAPI.Models
{
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        //public ICollection Reviews { get; set; }
        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int NumReviews { get; set; }
        public int CountInStock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
