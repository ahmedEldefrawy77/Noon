using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class WishListProductsConfiguration : IEntityTypeConfiguration<WishListProducts>
    {
        public void Configure(EntityTypeBuilder<WishListProducts> builder)
        {
            builder.HasKey(e => new { e.ProductId, e.WishListId });

            builder
                .HasOne(e=>e.WishList)
                .WithMany(e=>e.WishListProducts)
                .HasForeignKey(e=>e.WishListId);
            builder
                .HasOne(e => e.Product)
                .WithMany(e => e.WishListProducts)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
