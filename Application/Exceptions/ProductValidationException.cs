namespace Application.Exceptions
{
    public class ProductValidationException:Exception
    {
        public string ValidationCode { get; }

        public ProductValidationException() { }

        public ProductValidationException(string message) : base(message) { }

        public ProductValidationException(string message, string validationCode) : base(message)
        {
            ValidationCode = validationCode;
        }

        public ProductValidationException(string message, Exception inner) : base(message, inner) { }

        public ProductValidationException(string message, string validationCode, Exception inner) : base(message, inner)
        {
            ValidationCode = validationCode;
        }
    }
}
