using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Infrustructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.ProductPrice).IsRequired();
            builder.Property(p => p.ProductDescription);
            builder.Property(p => p.ProductPriority).IsRequired();
            builder.Property(p => p.ProductSlug).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
