namespace StockWatchApplication.Models.Contracts
{
    using System.Collections.Generic;
    using Utils;

    public interface IHistoricalDataAvailable
    {
        IList<DataPoint> HistoricalData { get; set; }
    }
}
