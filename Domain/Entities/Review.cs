using Domain.Entities.common;

namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public DateTime ReviewDate { get; private set; }
        public decimal Rating { get; private set; }
        public string Comment { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int CustomerId { get; private set; }
        public User Customer { get; private set; }

        public Review(string comment, decimal rating, int productId, int customerId)
        {
            ValidationComment(comment);
            ValidationRating(rating);
            ValidationCustomer(customerId);
            ReviewDate = DateTime.Now;
            ProductId = productId;
            CustomerId = customerId;
            Comment = comment;
            Rating = rating;
        }

        private void ValidationComment(string comment)
        {
            if (string.IsNullOrEmpty(Comment)) throw new ArgumentNullException("Comment cannot be empty");
        }
        private void ValidationRating(decimal rating)
        {
            if (rating < 1 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");
        }
        private void ValidationCustomer(int customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId.ToString())) throw new ArgumentException("CustomerId cannot be null or empty.");
        }

    }
}
