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
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(a => a.CustomerId).IsRequired();
            builder.Property(a => a.State).IsRequired().HasMaxLength(255);
            builder.Property(a => a.City).IsRequired().HasMaxLength(255);
            builder.Property(a => a.CompleteAddress).IsRequired().HasMaxLength(526);
            builder.Property(a => a.NoNumber).IsRequired();
            builder.Property(a => a.IsActive);
        }
    }
}
