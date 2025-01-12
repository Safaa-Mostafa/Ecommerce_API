using Domain.Entities.common;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Description { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool PrdStatus { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public virtual ICollection<Image> ImageUrls { get; private set; }
        public virtual ICollection<Discount> Discounts { get; private set; }
        public virtual ICollection<ProductOrder> OrderProducts { get; private set; }
        public virtual ICollection<Review> Reviews { get; private set; }

        public Product()
        {
            ImageUrls = new HashSet<Image>();
            Discounts = new HashSet<Discount>();
            Reviews = new HashSet<Review>();
        }

        public Product(string description, string name, decimal price, int stock, int categoryId) : this()
        {
            Validate();
            Description = description;
            Name = name;
            Price = price;
            StockQuantity = stock;
            CategoryId = categoryId;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ProductException("Product name cannot be null or empty.");
            if (Name.Length < 3 || Name.Length > 100)
                throw new ProductException("Product name must be between 3 and 100 characters.");
            if (string.IsNullOrWhiteSpace(Description))
                throw new ProductException("Product description cannot be null or empty.");
            if (Description.Length > 500)
                throw new ProductException("Product description cannot exceed 500 characters.");
            if (Price <= 0)
                throw new ProductException("Price must be greater than zero.");
            if (Price > 1_000_000)
                throw new ProductException("Price cannot exceed 1,000,000.");

            if (StockQuantity < 0)
                throw new ProductException("Stock quantity cannot be negative.");
            if (StockQuantity > 10_000)
                throw new ProductException("Stock quantity cannot exceed 10,000.");

            if (string.IsNullOrWhiteSpace(CategoryId.ToString()))
                throw new ProductException("Category ID cannot be null or empty.");
        }

        public void ReplenishStock(int quantity)
        {
            if (quantity <= 0)
                throw new ProductException("Replenish quantity must be greater than zero.");
            if (StockQuantity + quantity > 10_000)
                throw new ProductException("Stock quantity cannot exceed 10,000 after replenishment.");

            StockQuantity += quantity;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ProductException("Quantity to reduce must be greater than zero.");
            if (StockQuantity < quantity)
                throw new ProductException("Not enough stock available.");
            StockQuantity -= quantity;
        }

        public decimal GetDiscountedPrice()
        {
            decimal totalDiscount = Discounts.Sum(d => d.GetDiscountPercentage());
            return Math.Max(Price - (Price * (totalDiscount / 100)), 0);
        }

        public decimal CalculateAverageRating()
        {
            return Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
        }
    }
}