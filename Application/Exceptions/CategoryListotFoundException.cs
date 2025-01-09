namespace Application.Exceptions
{
    public class CategoryListotFoundException : Exception
    {
        public CategoryListotFoundException()
        {
        }
        public CategoryListotFoundException(string message)
            : base(message)
        {
        }
        public CategoryListotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
