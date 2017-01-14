namespace FinancialInstruments
{
    public class Stock : FinancialInstrument
    {
        public DataPoint PriceChange { get; private set; }
        public DataPoint PercentagePriceChange { get; private set; }
        public string Exchange { get; private set; }

        public Stock(string ticker, DataPoint price, DataPoint priceChange, DataPoint percentagePriceChange, string exchange)
        {
            this.Ticker = ticker;
            this.Price = price;
            this.PriceChange = priceChange;
            this.PercentagePriceChange = percentagePriceChange;
            this.Exchange = exchange;
        }
    }
}
