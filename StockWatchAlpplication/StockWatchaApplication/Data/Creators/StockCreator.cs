namespace StockWatchApplication.Data.Creators
{
    using System;
    using Models;
    using Models.Contracts;
    using Models.Enum;
    using Models.Utils;

    public static class StockCreator
    {
        internal static IStock CreateStock(string ticker, string exchange, DateTime date,
                                         decimal price, decimal priceChange, decimal percentagePriceChange)
        {
            DataPoint datePrice = new DataPoint(date, price);
            DataPoint datePriceChange = new DataPoint(date, priceChange);
            DataPoint datePercentagePriceChange = new DataPoint(date, percentagePriceChange);
            StockTicker tickerAsEnum = (StockTicker)Enum.Parse(typeof(StockTicker), ticker);

            Exchange exchangeAsEnum = (Exchange)Enum.Parse(typeof(Exchange), exchange);

            var currentStock = new Stock(ticker, datePrice, tickerAsEnum, datePriceChange,
                                         datePercentagePriceChange, exchangeAsEnum);
            return currentStock;
        }
    }
}
