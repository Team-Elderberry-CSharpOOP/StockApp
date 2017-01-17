namespace StockWatchApplication.Models.Contracts
{
    public interface IDerivative : IFinancialInstrument
    {
        string Underlying { get; }
    }
}
