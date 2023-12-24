using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Tokens;
using Noon.Infrastructure.Configuration.BaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class UserConfiguration :BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(15);

            builder.Property(e => e.LastName).IsRequired().HasMaxLength(15);

            builder.Property(e => e.Email).IsRequired().HasMaxLength(40);

            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(40);

            builder.Property(e => e.Password).IsRequired().HasMaxLength(int.MaxValue);

            builder.Property(e => e.Role).IsRequired().HasDefaultValue("User").HasMaxLength(5).ValueGeneratedOnAdd();

            builder.HasOne(e => e.RefreshToken).WithOne(e => e.User).HasForeignKey<RefreshToken>(e => e.UserId);

            builder.HasOne(e => e.WishList).WithOne(e => e.User).HasForeignKey<WishList>(e => e.WishListUserId);
            
        }
    }
}
