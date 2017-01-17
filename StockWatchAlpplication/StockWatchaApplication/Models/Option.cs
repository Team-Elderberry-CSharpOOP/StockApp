namespace StockWatchApplication.Models
{
    using Contracts;
    using Enum;
    using Utils;

    public class Option : FinancialInstrument, IOption, IDerivative, IFinancialInstrument
    {
        public Option(string name, DataPoint currentDate, string underlying, OptionType type)
            : base(name, currentDate)
        {
            this.Underlying = underlying;
            this.Type = type;
        }

        public OptionType Type { get; protected set; }

        public string Underlying { get; set; }
    }
}
