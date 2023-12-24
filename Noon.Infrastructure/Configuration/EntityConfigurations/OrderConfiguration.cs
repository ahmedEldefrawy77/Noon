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
    public class OrderConfiguration : BaseConfiguration<Order>
    {
       public override void Configure(EntityTypeBuilder<Order> builder) { 
            base.Configure(builder);

            builder.HasOne(e => e.User).WithMany(e=>e.Orders).HasForeignKey(e => e.OrderUserId);

            builder.Property(e => e.TotalPrice).IsRequired();

            
        }
    }
}
