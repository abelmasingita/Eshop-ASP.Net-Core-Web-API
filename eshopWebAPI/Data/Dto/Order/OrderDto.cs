using System.ComponentModel.DataAnnotations.Schema;

namespace eshopWebAPI.Data.Dto.Order
{
    public class OrderDto : OrderBaseDto
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
    }
}
