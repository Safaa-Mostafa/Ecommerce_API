using System.ComponentModel.DataAnnotations;
using Domain.Entities.common;
using Domain.Enums;

namespace Domain.Entities
{
    public class ProductOrder : BaseEntity
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountApplied { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public OrderStatus Status { get; set; }
    

    }
}
