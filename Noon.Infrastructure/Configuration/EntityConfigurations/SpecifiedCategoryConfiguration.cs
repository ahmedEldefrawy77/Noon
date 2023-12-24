using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
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
    public class SpecifiedCategoryConfiguration : BaseConfiguration<SpecifiedCategory>
    {
        public override void Configure(EntityTypeBuilder<SpecifiedCategory> builder)
        {
            base.Configure(builder);

            builder.Property(e=>e.Name).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e=>e.SpecifiedCategories).HasForeignKey(e => e.CategoryId);
        }
    }
}
