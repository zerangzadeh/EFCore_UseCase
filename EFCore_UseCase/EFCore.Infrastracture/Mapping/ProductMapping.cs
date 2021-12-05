using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Domain.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).HasMaxLength(255);
            builder .Property(x=>x.ProductName).IsRequired();
            builder.HasOne(x=>x.ProductCategory)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.CategoryID);

        }
    }
}
