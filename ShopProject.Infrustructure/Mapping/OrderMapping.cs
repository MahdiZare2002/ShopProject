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
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CustomerId).IsRequired();
            builder.Property(o => o.AddressId).IsRequired();
            builder.Property(o => o.OrderStatus).IsRequired();
            builder.Property(o => o.PaymentMethod).IsRequired();
            builder.Property(o => o.PaidDate).IsRequired();
            builder.Property(o => o.TotalAmount).IsRequired();
            
            builder.HasMany(o => o.orderDetails).WithOne().HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
