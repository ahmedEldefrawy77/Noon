using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noon.Domain.Entities.Products;
using Noon.Infrastructure.Configuration.BaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Configuration.EntityConfigurations
{
    public class BrandConfiguration : BaseConfiguration<Brand>
    {
        public BrandConfiguration(EntityTypeBuilder<Brand> builder) 
        {
            base.Configure(builder);

            builder.Property(e=>e.Name).IsRequired();

            builder.HasMany(e => e.Products).WithOne().HasForeignKey(e=>e.BrandId);
        }
    }
}
