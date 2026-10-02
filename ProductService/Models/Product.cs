namespace ProductService.Models
{
    public class Product
    {
        public int Id { get; set; }  // In-memory DB auto-increment simulation
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
