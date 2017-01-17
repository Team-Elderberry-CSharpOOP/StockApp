namespace StockWatchApplication.Models.Contracts
{
    using System.Collections.Generic;

    public interface IIndex : IFinancialInstrument, IHistoricalDataAvailable
    {
        string Ticker { get; }

        IList<IStock> StockList { get; }
    }
}
