namespace eshopWebAPI.Dto.Product
{
    public abstract class ProductBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CountInStock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
