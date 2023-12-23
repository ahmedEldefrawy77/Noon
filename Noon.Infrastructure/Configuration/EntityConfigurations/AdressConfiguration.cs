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
    public class AdressConfiguration : BaseConfiguration<Address>
    {
        public AdressConfiguration(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.HasOne(e=>e.User).WithMany().HasForeignKey(e=>e.UserId);
            builder.Property(e => e.Street).IsRequired();
            builder.Property(e => e.City).IsRequired();
            builder.Property(e => e.PostalCode).IsRequired();
            builder.Property(e => e.Country).IsRequired();
        }
    }
}
