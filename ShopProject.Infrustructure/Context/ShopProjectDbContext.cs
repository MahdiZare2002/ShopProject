using Microsoft.EntityFrameworkCore;
using ShopProject.Domain.Entities;
using ShopProject.Infrustructure.Mapping;

namespace ShopProject.Infrustructure.Context
{
    public class ShopProjectDbContext : DbContext
    {
        public ShopProjectDbContext(DbContextOptions<ShopProjectDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
