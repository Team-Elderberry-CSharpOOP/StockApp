namespace FinancialInstruments
{
    public class Stock : FinancialInstrument
    {
        public DataPoint Data { get; private set; }

        public Stock(string ticker, DataPoint data)
        {
            this.Ticker = ticker;
            this.Data = data;
        }
    }
}
