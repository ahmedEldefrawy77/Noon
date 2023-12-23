using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noon.Domain.Entities;
using Noon.Infrastructure.Configuration.BaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class WishListConfiguration : BaseConfiguration<WishList>
    {
        public WishListConfiguration(EntityTypeBuilder<WishList> builder) 
        {
            base.Configure(builder);
            builder.HasOne(e => e.User).WithOne().HasForeignKey<WishList>(e => e.UsertId);
        }
    }
}
