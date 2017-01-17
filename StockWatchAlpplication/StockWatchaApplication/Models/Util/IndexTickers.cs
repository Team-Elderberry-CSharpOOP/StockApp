namespace StockWatchApplication.Models.Utils
{
    using System.Collections.Generic;

    public static class IndexTickers
    {

        #region All Index Tickers
        public static readonly IDictionary<string, string> Tickers = new Dictionary<string, string>
        {
            {"S&&P500", @"^GSPC"},
            {"DOW30", @"^DJI" },
            {"NASDAQ", @"^IXIC" },
            {"RUSSELL2000", @"^RUT" },
            {"DAX", @"^GDAXI" },
            {"FTSE 100", @"^FTSE" }
        };
        #endregion

        public static IDictionary<string, string> GetTickers()
        {
            return Tickers;
        }

        public static string GetTickerOf(string name)
        {
            return Tickers[name];
        }
    }
}
