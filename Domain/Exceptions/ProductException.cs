using Domain.Exception;
namespace Domain.Exceptions
{
    public class ProductException:DomainException
    {
        public ProductException() { }

        public ProductException(string message) : base(message) { }
    }
}
