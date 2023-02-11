namespace eshopWebAPI.Dto.Product
{
    public class ProductDto : ProductBaseDto
    {
        public int Id { get; set; } 
        public int NumReviews { get; set; }
        public double Rating { get; set; }
    }
}
