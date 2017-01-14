namespace FinancialInstruments
{
    using System.Collections.Generic;

    public class Index : FinancialInstrument
    {

        public List<DataPoint> Data { get; private set; }

        public Index(string ticker, List<DataPoint> data)
        {
            this.Ticker = ticker;
            this.Data = data;
        }

        public static readonly Dictionary<string, string> Tickers = new Dictionary<string, string>
        {
            {"S&&P 500", @"^GSPC"},
            {"DOW 30", @"^DJI" },
            {"NASDAQ", @"^IXIC" },
            {"RUSSELL 2000", @"^RUT" },
            {"DAX", @"^GDAXI" },
            {"FTSE 100", @"^FTSE" }
        };


    }
}
