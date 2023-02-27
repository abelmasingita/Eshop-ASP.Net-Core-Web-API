using System.ComponentModel.DataAnnotations.Schema;

namespace eshopWebAPI.Data.Dto.Order
{
    public class OrderBaseDto
    {

        public string paymentMethod { get; set; }
        public string paymentResult { get; set; }
        public double taxPrice { get; set; }

        public double shippingPrice { get; set; }
        public double totalPrice { get; set; }

        public bool isPaid { get; set; }
        public bool isDelivered { get; set; }

        public DateTime paidAt { get; set; }
        public DateTime deliveredAt { get; set; }

     
    }
}
