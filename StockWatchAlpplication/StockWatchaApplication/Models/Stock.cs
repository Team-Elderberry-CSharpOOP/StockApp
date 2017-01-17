namespace StockWatchApplication.Models
{
    using Contracts;
    using Enum;
    using System.Collections.Generic;
    using Utils;

    public class Stock : FinancialInstrument, IStock, IHistoricalDataAvailable
    {
        public Stock(string name, DataPoint currentPrice, StockTicker ticker, DataPoint priceChange, DataPoint percentagePriceChange, Exchange exchange)
            : base(name, currentPrice)
        {
            this.Ticker = ticker;
            this.PriceChange = priceChange;
            this.PercentagePriceChange = percentagePriceChange;
            this.Exchange = exchange;
        }

        public Exchange Exchange { get; protected set; }

        public IList<DataPoint> HistoricalData { get; set; }

        public DataPoint PercentagePriceChange { get; set; }

        public DataPoint PriceChange { get; set; }

        public StockTicker Ticker { get; protected set; }
    }
}
