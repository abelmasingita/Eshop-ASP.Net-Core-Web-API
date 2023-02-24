using System.ComponentModel.DataAnnotations.Schema;


namespace eshopWebAPI.Dto.Product
{
    public class CreateProductDto : ProductBaseDto
    {
        public string? UserId { get; set; }
    }
}
