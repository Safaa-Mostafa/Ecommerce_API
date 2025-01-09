using Domain.Entities.common;

namespace Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Url { get; private set; }
        public string ProductId { get; private set; }
        public Product Product { get; private set; }
        public Image(string url, string productId,string Id)
        {
            EnsureValidUrl(url); 
            EnsureValidProductId(productId);
            Url = url;
            ProductId = productId;
        }
        private void EnsureValidProductId(string productId)
        {
            if (string.IsNullOrEmpty(productId)) throw new ArgumentException("Product ID cannot be null or empty.", nameof(productId));
        }
        private void EnsureValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute)) throw new ArgumentException("Invalid URL.", nameof(url));
        }
        public void Update(string url, string productId)
        {
            EnsureValidUrl(url);
            EnsureValidProductId(productId);

            Url = url;
            ProductId = productId;
        }
    }
}
