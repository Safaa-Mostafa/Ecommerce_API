using System.Diagnostics;
using System.Xml.Linq;
using Domain.Entities.common;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Description { get; private set; }
        public string Name { get; private set; } 
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool PrdStatus { get; private set; }

        public virtual ICollection<Image> ImageUrls { get; private set; }
        public Category Category { get; private set; }
        public string CategoryId { get; private set; }
        public virtual ICollection<Discount> Discounts { get; private set; }
        public virtual ICollection<ProductOrder> OrderProducts { get; set; }
        public virtual ICollection<Review> Reviews { get; private set; }

        public Product(string description,string name, decimal price, int stock, ICollection<Image> images, string categoryId, Discount discounts)
        {
            ValidateName(name);
            ValidatePrice(price);
            ValidateStock(stock);
            ValidateImages(images);
            ValidateCategory(categoryId);
            ValidateDiscount(discounts);
            ValidateDescription(description);
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stock;
            ImageUrls = images;
            CategoryId = categoryId;
            Discounts.Add(discounts);
        }

        private void ValidateName(string name)
        {
            ArgumentNullException.ThrowIfNull("name");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Product name cannot be empty.");
        }
        private void ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("Product description cannot be empty.");
        }
        private void ValidatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
        }
        private void ValidateStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentException("Stock cannot be negative.");
        }
        private void ValidateImages(ICollection<Image> images)
        {
            if (images.Count == 0 || images is null) throw new ArgumentException("At least one image is required.");
        }
        private void ValidateCategory(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId)) throw new ArgumentNullException("CategoryId cannot be null or empty.");
        }
        private void ValidateDiscount(Discount discounts)
        {
            if (discounts is null) throw new ArgumentException("Discount cannot be null");
        }
        public decimal CalculateAverageRating()
        {
            if (Reviews.Count == 0)
                return 1;
            decimal averageRating = Reviews.Average(r => r.Rating);
            return Math.Min(averageRating, 5);
        }
        public void ReplenishStock(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Replenish quantity must be positive.");
            StockQuantity += quantity;
        }
        public void ReduceInStock(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity to reduce must be positive.");
            if (StockQuantity < quantity) throw new InvalidOperationException("Not enough stock available.");
            StockQuantity -= quantity;
        }
        public void ApplyDiscount(Discount discount)
        {
            ValidateDiscount(discount);
            Discounts.Add(discount);
            RecalculatePrice();
        }
        public void RemoveDiscount(Discount discount)
        {
            ValidateDiscount(discount);
            if (!Discounts.Contains(discount)) throw new ArgumentException("Discount not found in the product's discounts.");
            Discounts.Remove(discount);
        }
        public void RecalculatePrice()
        {
            decimal totalDiscount = Discounts.Sum(d => d.Percentage);
            Price = Math.Max(Price - (Price * (totalDiscount / 100)), 0);
        }
        public void RemoveImage(Image image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image), "Image cannot be null.");
            if (ImageUrls.Contains(image)) ImageUrls.Remove(image);
        }
        public void AddImage(Image image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image), "Image cannot be null.");
            ImageUrls.Add(image);
        }
        public void AddReview(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            if (review.ProductId != Id)
                throw new ArgumentException("The review does not belong to this product.");

            if (Reviews.Any(r => r.CustomerId == review.CustomerId))
                throw new InvalidOperationException("A customer can only leave one review per product.");

            Reviews.Add(review);
            RecalculatePrice();
        }
    }
}

