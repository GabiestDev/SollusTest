namespace SollusTest.Responses
{
    public record ProductResponse(Guid Id, string Name, string Description, decimal Price, StorageResponse? Quantity);
}
