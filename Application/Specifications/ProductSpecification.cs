using Domain.Entities;

namespace Application.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification()
        {

            AddIncludes(p => p.OrderProducts);
            ApplyPaging(0, 10);
            AddOrderBy(p => p.Name);
            ApplyPaging(0, 10);

        }
        public ProductSpecification(string categoryId)
        {
            SetCriteria(p => p.Price > 100 && p.CategoryId == categoryId);
        }
    }
}
