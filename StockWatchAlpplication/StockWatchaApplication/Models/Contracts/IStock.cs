namespace StockWatchApplication.Models.Contracts
{
    using Enum;
    using Utils;

    public interface IStock : IFinancialInstrument, IHistoricalDataAvailable
    {
        StockTicker Ticker { get; }

        Exchange Exchange { get; }

        DataPoint PriceChange { get; set;  }

        DataPoint PercentagePriceChange { get; set; }
    }
}
