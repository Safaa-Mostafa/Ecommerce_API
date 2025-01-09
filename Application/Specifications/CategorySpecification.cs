using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Specifications
{
    public class CategorySpecification : BaseSpecification<Category>
    {
        public CategorySpecification()
        {
            Includes.Add(p => p.Products);
        }
    }
}
