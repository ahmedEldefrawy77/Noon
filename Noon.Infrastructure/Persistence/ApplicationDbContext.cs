using Microsoft.EntityFrameworkCore;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Products;
using Noon.Domain.Entities.Tokens;
using Noon.Infrastructure.Configuration.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<SpecifiedCategory> SpecifiedCategories { get; set; }
        public DbSet<Money> Moneys { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly)
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new OrderConfiguration())
                .ApplyConfiguration(new WishListConfiguration())
                .ApplyConfiguration(new SpecifiedCategoryConfiguration())
                .ApplyConfiguration(new ReturnConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new BrandConfiguration())
                .ApplyConfiguration(new AddressConfiguration())
                .ApplyConfiguration(new MoneyConfiguration());


        }

    }

}
