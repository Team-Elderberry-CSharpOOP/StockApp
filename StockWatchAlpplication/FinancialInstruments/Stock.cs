namespace FinancialInstruments
{
    public class Stock
    {
        public string Ticker { get; private set; }
        public DataPoint Data { get; private set; }

        public Stock(string ticker, DataPoint data)
        {
            this.Ticker = ticker;
            this.Data = data;
        }
    }
}
