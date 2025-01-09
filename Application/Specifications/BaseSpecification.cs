using System.Linq.Expressions;
using Application.Interfaces;

namespace Application.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderExpression)
        {
            OrderBy = orderExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderExpression)
        {
            OrderByDescending = orderExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        protected void SetCriteria(Expression<Func<T, bool>> criteriaExpression) => Criteria = criteriaExpression;
    }


}
