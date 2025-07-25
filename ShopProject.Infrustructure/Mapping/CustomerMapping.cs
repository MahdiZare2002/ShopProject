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
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserName).IsRequired().HasMaxLength(128);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(128);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(128);
            builder.Property(c => c.IsActive);
            builder.Property(c => c.IsBlocked);
        }
    }
}
