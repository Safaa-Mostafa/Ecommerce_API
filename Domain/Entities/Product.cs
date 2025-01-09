using Domain.Entities.common;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Description { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool PrdStatus { get; private set; }

        public string CategoryId { get; private set; }
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

        public Product(string description, string name, decimal price, int stock, string categoryId) : this()
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
                throw new ProductValidationException("Product name cannot be null or empty.", "NAME_NULL_OR_EMPTY");
            if (Name.Length < 3 || Name.Length > 100)
                throw new ProductValidationException("Product name must be between 3 and 100 characters.", "NAME_LENGTH_INVALID");
            if (string.IsNullOrWhiteSpace(Description))
                throw new ProductValidationException("Product description cannot be null or empty.", "DESCRIPTION_NULL_OR_EMPTY");
            if (Description.Length > 500)
                throw new ProductValidationException("Product description cannot exceed 500 characters.", "DESCRIPTION_LENGTH_EXCEEDED");
            if (Price <= 0)
                throw new ProductValidationException("Price must be greater than zero.", "PRICE_INVALID");
            if (Price > 1_000_000)
                throw new ProductValidationException("Price cannot exceed 1,000,000.", "PRICE_TOO_HIGH");

            if (StockQuantity < 0)
                throw new ProductValidationException("Stock quantity cannot be negative.", "STOCK_NEGATIVE");
            if (StockQuantity > 10_000)
                throw new ProductValidationException("Stock quantity cannot exceed 10,000.", "STOCK_TOO_HIGH");

            if (string.IsNullOrWhiteSpace(CategoryId))
                throw new ProductValidationException("Category ID cannot be null or empty.", "CATEGORY_ID_NULL_OR_EMPTY");
            if (CategoryId.Length != 36)
                throw new ProductValidationException("Category ID must be a valid GUID.", "CATEGORY_ID_INVALID");
        }

        public void ReplenishStock(int quantity)
        {
            if (quantity <= 0)
                throw new ProductValidationException("Replenish quantity must be greater than zero.", "REPLENISH_QUANTITY_INVALID");
            if (StockQuantity + quantity > 10_000)
                throw new ProductValidationException("Stock quantity cannot exceed 10,000 after replenishment.", "STOCK_TOO_HIGH_AFTER_REPLENISHMENT");

            StockQuantity += quantity;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ProductValidationException("Quantity to reduce must be greater than zero.", "REDUCE_QUANTITY_INVALID");
            if (StockQuantity < quantity)
                throw new ProductValidationException("Not enough stock available.", "STOCK_INSUFFICIENT");
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
