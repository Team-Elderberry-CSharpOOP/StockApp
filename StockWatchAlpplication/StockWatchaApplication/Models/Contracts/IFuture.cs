namespace StockWatchApplication.Models.Contracts
{
    public interface IFuture : IFinancialInstrument, IDerivative
    {
        long ContractSize { get; }
    }
}
