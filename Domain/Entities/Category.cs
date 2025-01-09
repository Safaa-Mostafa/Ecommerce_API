using Domain.Entities.common;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            
        }
        public Category(string name, string description, string Id)
        {
            EnsureValidCategory(name, description, Id);
            Name = name;
            Description = description;
        }
        private void EnsureValidCategory(string name, string description, string Id)
        {
            ValidateName(name);
            ValidateDescription(description);
        }
        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
        }
        private void ValidateDescription(string description)
        {
            if (!string.IsNullOrEmpty(description)) throw new ArgumentNullException("description");
        }
        private void ValidateProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
        }
        public Category Update(Category category)
        {
            ValidateDescription(category.Description);
            ValidateName(category.Name);
            category.Name = Name;
            category.Description = Description;
            return category;
        }
        public void AddProduct(Product product)
        {
            ValidateProduct(product);
            if (Products.Contains(product)) throw new InvalidOperationException("Product is aleardy exist into this category.");
            Products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            ValidateProduct(product);
            if (!Products.Contains(product)) throw new InvalidOperationException("Product does not belong to this category.");
            Products.Remove(product);
        }
    }
}
