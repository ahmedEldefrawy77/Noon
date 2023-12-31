﻿using Microsoft.EntityFrameworkCore;
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
    public class ReturnConfiguration : BaseConfiguration<Return>
    {
        public override void Configure(EntityTypeBuilder<Return> builder)
        {
            base.Configure(builder);

            builder.HasOne(e=>e.User).WithMany(e=>e.Returns).HasForeignKey(e=>e.ReturnUserId);

            builder.Property(e=>e.Status).HasDefaultValue(false);
        }
    }
}
