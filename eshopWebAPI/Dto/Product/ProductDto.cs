namespace eshopWebAPI.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        //public ICollection Reviews { get; set; }
        //public string User { get; set; }    
        public int NumReviews { get; set; }
        public int CountInStock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
