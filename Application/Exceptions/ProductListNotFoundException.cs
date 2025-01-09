namespace Application.Exceptions
{
    public class ProductListNotFoundException : Exception
    {
        public ProductListNotFoundException()
        {
        }

        public ProductListNotFoundException(string message)
            : base(message)
        {
        }

        public ProductListNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
