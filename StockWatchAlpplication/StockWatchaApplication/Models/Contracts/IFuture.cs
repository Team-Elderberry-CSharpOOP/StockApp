namespace StockWatchApplication.Models.Contracts
{
    public interface IFuture : IDerivative
    {
        long ContractSize { get; }
    }
}
