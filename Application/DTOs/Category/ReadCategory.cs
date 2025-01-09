using Application.DTOs.Product;

namespace Application.DTOs.Category
{
    public class ReadCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ReadProduct>? Products { get; set; }

    }
}
