namespace Application.DTOs.Product
{
    public class ReadProduct
    {
        public string? Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryId { get; set; }
        public decimal Rate { get; set; }
    }
}
