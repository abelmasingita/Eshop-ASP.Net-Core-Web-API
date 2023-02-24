using System.ComponentModel.DataAnnotations.Schema;

namespace eshopWebAPI.Dto.Product
{
    public class UpdateProductDto : ProductBaseDto
    {
       
        public string Id { get; set; }
    }
}
