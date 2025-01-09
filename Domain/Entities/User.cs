using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public Image? ProfilePicture { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public void RemoveAddress(Address address)
        {
            if (!Addresses.Contains(address)) { throw new InvalidOperationException("Address does not belong to this User."); }
            RemoveAddress(address);
        }
    }
}