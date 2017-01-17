namespace StockWatchApplication.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utils;

    public class Index : FinancialInstrument, IIndex, IFinancialInstrument, IHistoricalDataAvailable
    {
        private const string InvalidIndexExceptionMessage = "Index not found";

        #region All Index and Tickers Available 
        public static readonly Dictionary<string, string> Tickers = new Dictionary<string, string>
        {
            {"S&&P 500", @"^GSPC"},
            {"DOW 30", @"^DJI" },
            {"NASDAQ", @"^IXIC" },
            {"RUSSELL 2000", @"^RUT" },
            {"DAX", @"^GDAXI" },
            {"FTSE 100", @"^FTSE" }
        };
        #endregion
        private string name;

        public Index(string name, DataPoint currentPrice, IList<IStock> stockList, IList<DataPoint> data)
            : base()
        {
            this.Name = name;
            this.Ticker = Index.Tickers[name];
            this.CurrentPrice = currentPrice;
            this.HistoricalData = data;
            this.StockList = stockList;
        }

        public new string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (!Index.Tickers.ContainsKey(value))
                {
                    throw new ArgumentException(InvalidIndexExceptionMessage);
                }

                this.name = value;
            }
        }

        public string Ticker { get; protected set; }

        public IList<IStock> StockList { get; protected set; }

        public IList<DataPoint> HistoricalData { get; set; }

    }
}
