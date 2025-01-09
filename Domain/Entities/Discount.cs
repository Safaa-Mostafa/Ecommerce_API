using Domain.Entities.common;

namespace Domain.Entities
{
    public class Discount : BaseEntity
    {
        public decimal Percentage { get; private set; }
        public DateTime ValidFrom { get; private set; }
        public DateTime ValidTo { get; private set; }
        public string Code { get; private set; }
        public bool IsActive => IsValid(DateTime.Now);
        public Discount()
        {

        }
        private void Validate(decimal percentage, string code)
        {
            if (percentage == null)
                throw new ArgumentNullException(nameof(percentage), "Percentage cannot be null.");
            if (code == null)
                throw new ArgumentNullException(nameof(code), "code cannot be null.");
        }
        public decimal GetDiscountPercentage()
        {
            return Percentage;
        }
        public bool IsValid(DateTime currentDate) => currentDate >= ValidFrom && currentDate <= ValidTo;
        public Discount(decimal discountPercentage, DateTime startDate, DateTime endDate)
        {
            Percentage = discountPercentage;
            ValidFrom = startDate;
            ValidTo = endDate;
            Code = null;
        }
        public Discount(decimal percentage, DateTime startDate, DateTime endDate, string code)
        {
            Validate(percentage, code);
            Percentage = percentage;
            ValidFrom = startDate;
            ValidTo = endDate;
            Code = code;
        }


    }
}
