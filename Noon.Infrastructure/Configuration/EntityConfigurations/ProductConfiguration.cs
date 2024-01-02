
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Noon.Domain.Entities.Products;
using Noon.Infrastructure.Configuration.BaseConfig;
using Noon.Infrastructure.IdentityProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noon.Infrastructure.DictionaryComparer;
using Microsoft.EntityFrameworkCore;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.SpecifiedCategory).WithMany(e=>e.Products).HasForeignKey(e => e.SpecifiedCategoryId);

            builder.HasOne(e=>e.Brand).WithMany(e=>e.Products).HasForeignKey(e=>e.BrandId);
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.NoAction); 

            builder.Property(e => e.Specifications).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v) ?? new Dictionary<string, string>())
                .Metadata.SetValueComparer(new DictionaryComparer<string, string>()); ;


        }
    }
}
