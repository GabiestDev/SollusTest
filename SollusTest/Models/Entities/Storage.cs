using SollusTest.Requests;

namespace SollusTest.Models.Entities
{
    public class Storage
    {
        public Storage()
        {
            
        }
        public Storage(StorageRequest storage)
        {
            this.Quantity = storage.Quantity;
        }

        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
    }
}
