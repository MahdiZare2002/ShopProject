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
    public class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(od => od.Id);

            builder.Property(od => od.OrderId).IsRequired();
            builder.Property(od => od.ProductId).IsRequired();
            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(od => od.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
