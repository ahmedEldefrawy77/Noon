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
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
           
        }
    }
}
