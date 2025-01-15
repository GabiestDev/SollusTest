using SollusTest.Requests;

namespace SollusTest.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Storage? Storage { get; set; }


        public Product()
        {
        }

        public Product(ProductRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Description = request.Description;
            Price = request.Price;
            Storage = request.Storage is null? null : new Storage(request.Storage);
        }
    }
}
