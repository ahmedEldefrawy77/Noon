using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class MoneyConfiguration : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
           builder.HasKey(x => x.Id);
            builder.HasOne(e=>e.Product).WithOne(e=>e.Price).HasForeignKey<Money>(e => e.ProductId);
            builder.Property(e=>e.Amount).IsRequired().HasPrecision(18,2);
            builder.Property(e=>e.Currency).IsRequired().HasMaxLength(3);
        }
    }
}
