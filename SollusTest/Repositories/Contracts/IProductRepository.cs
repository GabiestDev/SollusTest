using SollusTest.Models.Entities;

namespace SollusTest.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task<List<Product>> GetAll();
        Task<Product?> GetById(Guid id);
    }
}
