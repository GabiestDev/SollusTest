namespace SollusTest.Requests
{
    public record ProductRequest(
        string Name, 
        string Description,
        decimal Price,
        StorageRequest Storage);
}
