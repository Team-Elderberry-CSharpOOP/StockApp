namespace StockWatchApplication.Data.Providers
{
    using Download;
    using Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class ProvideStockCurrentData
    {
        public static IList<IStock> Provide()
        {
            var currenStockPrices = ReadCurrentDataFromFile.ReadPriceChanges(
                DownloadedFile.ProvideCurrentDataFile());

            return currenStockPrices;
        }
    }
}
