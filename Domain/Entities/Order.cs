using Domain.Entities.common;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public decimal DiscountPercentage { get; private set; }
        public string? DiscountCode { get; private set; }
        public ICollection<ProductOrder> OrderProducts { get; set; } = new List<ProductOrder>();
        public Order(int Id, int userId,string DiscountCode)
        {
            ValidateDiscountCode(DiscountCode);
            UserId = userId;
            OrderDate = DateTime.UtcNow;
        }
        public void AddProduct(ProductOrder productOrder)
        {
            OrderProducts.Add(productOrder);
            RecalculateAmount();
        }
        private void ValidateDiscountCode(string DiscountCode)
        {
            if (string.IsNullOrWhiteSpace(DiscountCode)) throw new ArgumentNullException(nameof(DiscountCode), "Discount code cannot be null or empty."); 
        }
        private void ValidateProductOrder(ProductOrder productOrder)
        {
            if (productOrder is null) throw new ArgumentNullException(nameof(productOrder));
        }
        private void RecalculateAmount()
        {
            decimal totalAmount = OrderProducts.Sum(po => po.Price * po.Quantity);
            if (DiscountPercentage > 0)
            {
                Amount -= Amount * (DiscountPercentage / 100);
            }
        }
    }
}
