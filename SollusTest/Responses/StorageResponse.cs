namespace SollusTest.Responses
{
    public class StorageResponse
    {
        public StorageResponse(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}