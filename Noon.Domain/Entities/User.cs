using Noon.Domain.Common;
using Noon.Domain.Entities.Products;
using Noon.Domain.Entities.Tokens;


namespace Noon.Domain.Entities
{
    public class User : BaseEntityUserSettings
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public DateTime DateCreatedAt { get; set; }
        public DateTime DateUpdatedAt { get; set; }
        public ICollection<Order>? Orders { get; set; }  
        public ICollection<Address>? Address {  get; set; }
        public ICollection<Return>? Returns { get; set; }
        public ICollection<Product>? Products { get; set; }
        
        public RefreshToken RefreshToken { get; set; } = new RefreshToken();

    }
}
