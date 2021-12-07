using EFCore.Domain.Mapping;
using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Application;
using EFCore.Application.Contracts;
using EFCore.Infrastracture.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Infrastracture
{
    public class EFContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }



        


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
         //   modelBuilder.ApplyConfiguration(new ProductMapping());
          //  modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            var assambly=typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);
            base.OnModelCreating(modelBuilder);

        }
      

    }
}
