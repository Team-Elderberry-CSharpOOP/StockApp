namespace StockWatchApplication.Models.Contracts
{
    using Utils;

    public interface IFinancialInstrument
    {
        string Name { get; }

        DataPoint CurrentPrice { get; set; }

        decimal Risk { get; }
    }
}
