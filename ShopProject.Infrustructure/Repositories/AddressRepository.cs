using Microsoft.EntityFrameworkCore;
using ShopProject.Domain.Entities;
using ShopProject.Domain.Interfaces.Repositories;
using ShopProject.Infrustructure.Context;

namespace ShopProject.Infrustructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShopProjectDbContext _context;
        public AddressRepository(ShopProjectDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Address entity)
        {
            await _context.Addresses.AddAsync(entity);
        }

        public void Delete(Address entity)
        {
            _context.Addresses.Remove(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Addresses.AnyAsync(a => a.Id == id);
        }

        public async Task<List<Address>> GetAllByCustomerIdAsync(int id)
        {
            return await _context.Addresses
                .Where(a => a.CustomerId == id)
                .Where(a => a.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Address entity)
        {
            _context.Addresses.Update(entity);
        }
    }
}
