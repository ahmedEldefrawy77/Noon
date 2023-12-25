using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public  void Configure(EntityTypeBuilder<OrderProduct> builder)
        {

            builder
                .HasKey(x=> new {x.OrderId, x.ProductId});

            builder.HasOne(e=>e.Orders)
                .WithMany(e=>e.OrdersProducts)
                .HasForeignKey(e=>e.OrderId);
            builder
                .HasOne(e => e.Products)
                .WithMany(e => e.OrdersProducts)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
