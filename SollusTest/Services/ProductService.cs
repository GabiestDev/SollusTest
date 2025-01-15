using SollusTest.Models.Entities;
using SollusTest.Repositories.Contracts;
using SollusTest.Requests;
using SollusTest.Responses;
using SollusTest.Services.Contracts;

namespace SollusTest.Services
{
    public class ProductService : IProductService
    {   
        private readonly IProductRepository _repository;    
        public ProductService(IProductRepository repository)
        {
            _repository = repository;    
        }

        public async Task Create(ProductRequest request)
        {
            Product product = new(request);
            await _repository.Create(product);
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            var products = await _repository.GetAll();
            var response = new List<ProductResponse>();

            foreach (var product in products) {
                response.Add(new ProductResponse(
                    product.Id, 
                    product.Name, 
                    product.Description, 
                    product.Price,
                    product.Storage is null? null : new(product.Storage.Quantity)));
            }

            return response;
        }

        public async Task<Product?> GetById(Guid Id)
        {
            return await _repository.GetById(Id);
        }
        
    }
}
