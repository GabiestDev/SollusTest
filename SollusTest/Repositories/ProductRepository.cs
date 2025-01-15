using Microsoft.EntityFrameworkCore;
using SollusTest.Data;
using SollusTest.Models.Entities;
using SollusTest.Repositories.Contracts;

namespace SollusTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Product.Include(x => x.Storage).ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
