using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Products;
using Noon.Infrastructure.Configuration.BaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class AddressConfiguration : BaseConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.HasOne(e=>e.User).WithMany().HasForeignKey(e=>e.AddressUserId);
            builder.Property(e => e.Street).IsRequired();
            builder.Property(e => e.City).IsRequired();
            builder.Property(e => e.PostalCode).IsRequired();
            builder.Property(e => e.Country).IsRequired();
        }
    }
}
