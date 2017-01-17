namespace StockWatchApplication.Data.Creators
{
    using Models;
    using Models.Contracts;
    using Models.Utils;
    using System.Collections.Generic;

    public static class IndexCreator
    {
        internal static IIndex CreateIndex(string name, DataPoint currentPrice, IList<IStock> stockList, IList<DataPoint> historicalData)
        {
            return new Index(name, currentPrice, stockList, historicalData);
        }
    }
}
