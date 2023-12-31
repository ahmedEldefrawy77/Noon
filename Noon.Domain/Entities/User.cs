﻿using Noon.Domain.Common;
using Noon.Domain.Entities.Products;
using Noon.Domain.Entities.Tokens;
using System.Text.Json.Serialization;


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
        //public ICollection<WarrantyClaim>? WarrantyClaims { get; set; }
        public ICollection<WishList>? WishList { get; set; }
        public ICollection<OTP>? OTPs { get; set; }
        [JsonIgnore]
        public RefreshToken RefreshToken { get; set; } = new RefreshToken();

    }
}