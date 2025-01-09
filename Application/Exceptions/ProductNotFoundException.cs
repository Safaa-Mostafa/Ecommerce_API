namespace Application.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string productId)
          : base($"Product with ID '{productId}' not found.") { }
    }
}
