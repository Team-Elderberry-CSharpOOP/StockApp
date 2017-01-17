namespace StockWatchApplication.Data.Providers
{
    using System;
    using System.Collections.Generic;
    using Creators;
    using DataReaders;
    using Download;
    using Models.Contracts;
    using Models.Utils;

    public class ProvideIndexHistoricalData
    {
        public static IIndex Provide(string name, DateTime startDate, DateTime endDate, string frequency)
        {
            var historicalData = ReadDataFromFile.ReadDataSeriesFromFile(
                DownloadedFile.ProvideHistoridalDataFile(name, startDate,endDate, frequency));

            var currentPrice = new DataPoint(); //currently not available
            var listOfStocks = new List<IStock>(); //currently not available

            var index = IndexCreator.CreateIndex(name, currentPrice, listOfStocks, historicalData);

            return index;
        }
    }
}
