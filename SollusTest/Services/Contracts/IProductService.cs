using SollusTest.Requests;
using SollusTest.Responses;

namespace SollusTest.Services.Contracts
{
    public interface IProductService
    {
        Task Create(ProductRequest request);
        Task<List<ProductResponse>> GetAll();
    }
}
