namespace StockWatchApplication.Data.Download
{
    using System;
    using System.Text;
    using Models.Enum;

    public static class URL
    {
        const string urlDataSeriesPrototype = @"http://ichart.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g={7}&ignore=.csv";
        const string urlCurrentDataPrototype = @"http://finance.google.com/finance/info?client=ig&q={0}";

        //creating the URL with the provided information for the historical data of one Index/Stock
        internal static string BuildURLHistoricalData(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            int startMonth = startDate.Month - 1; //in yahoo finance the months start from zero i.e January = 0
            int startDay = startDate.Day;
            int startYear = startDate.Year;

            int endMonth = endDate.Month - 1; //in yahoo finance the months start from zero i.e January = 0
            int endDay = endDate.Day;
            int endYear = endDate.Year;

            return string.Format(urlDataSeriesPrototype,
                ticker,
                startMonth,
                startDay,
                startYear,
                endMonth,
                endDay,
                endYear,
                frequency);
        }

        //Create a URL for the current prices of all stocks
        internal static string BuildURLCurrentPrices()
        {
            StringBuilder allTickers = new StringBuilder();

            foreach (StockTicker stockTicker in Enum.GetValues(typeof(StockTicker)))
            {
                allTickers.Append(stockTicker + ",");
            }

            string tickers = allTickers.ToString();
            tickers = tickers.Substring(0, tickers.Length - 1);

            return string.Format(urlCurrentDataPrototype, tickers);
        }
    }
}
