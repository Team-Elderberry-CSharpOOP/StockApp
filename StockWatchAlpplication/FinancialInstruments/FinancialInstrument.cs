namespace FinancialInstruments
{
    public abstract class FinancialInstrument
    {
        public string Ticker { get; internal set; }
        public DataPoint Price { get; internal set; }
    }
}
