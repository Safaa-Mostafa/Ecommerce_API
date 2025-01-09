using System.Xml.Linq;
using Domain.Entities.common;

namespace Domain.Entities
{
    public class Discount : BaseEntity
    {
        public decimal Percentage { get;private set; }
        public DateTime ValidFrom { get;private set; }
        public DateTime ValidTo { get;private set; }
        public string Code { get;private set; }
        public bool IsActive => IsValid(DateTime.Now);

        public void ValidatePercetage(decimal percentage)
        {
            if (percentage == null)
                throw new ArgumentNullException(nameof(percentage), "Percentage cannot be null.");
        }
        public void ValidateCode(string code)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code), "code cannot be null.");
        }
        public bool IsValid(DateTime currentDate) => currentDate >= ValidFrom && currentDate <= ValidTo; 
        public Discount(decimal discountPercentage, DateTime startDate, DateTime endDate)
        {
            Percentage = discountPercentage;
            ValidFrom = startDate;
            ValidTo = endDate;
            Code = null;
        }
        public Discount(decimal discountPercentage, DateTime startDate, DateTime endDate, string code)
        {
            Percentage = discountPercentage;
            ValidFrom = startDate;
            ValidTo = endDate;
            Code = code;
        }
       
      
    }
}
