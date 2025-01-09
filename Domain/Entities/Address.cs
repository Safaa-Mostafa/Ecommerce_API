using Domain.Entities.common;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }

        public Address(string addressLine1, string addressLine2, string city, string Id)
        {
            EnsureValidAddress(addressLine1, addressLine2, city,Id);
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
        }
        private void EnsureValidAddress(string addressLine1, string addressLine2, string city, string Id)
        {
            ValidateAddressLine1(addressLine1);
            ValidateAddressLine2(addressLine2);
            ValidateCity(city);
            ValidateId(Id);
        }
        private void ValidateAddressLine1(string addressLine1)
        {
            if (string.IsNullOrEmpty(addressLine1))throw new ArgumentException("Address Line 1 is required.", nameof(addressLine1));                                                                                                                                       
        }
        private void ValidateAddressLine2(string addressLine2)
        {
            if (addressLine2 != null && addressLine2.Length > 100) throw new ArgumentException("Address Line 2 cannot exceed 100 characters.", nameof(addressLine2));
        }
        private void ValidateCity(string city)
        {
            if (string.IsNullOrEmpty(city))throw new ArgumentException("City is required.", nameof(city));
        }
        public void UpdateAddress(string addressLine1, string addressLine2, string city,string Id)
        {
            EnsureValidAddress(addressLine1, addressLine2, city,Id);
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
        }
    }
}
