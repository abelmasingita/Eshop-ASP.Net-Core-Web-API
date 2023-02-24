using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eshopWebAPI.Models
{
    public class Order
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string paymentMethod { get; set; }
        public string paymentResult { get; set; }
        public double taxPrice { get; set; }

        public double shippingPrice { get; set; }
        public double totalPrice { get; set; }

        public bool isPaid { get; set; }
        public bool isDelivered { get; set; }

        public DateTime paidAt { get; set; }
        public DateTime deliveredAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public User? User { get; set; }

        // public List<> orderItems {get;set;}

    }
}
