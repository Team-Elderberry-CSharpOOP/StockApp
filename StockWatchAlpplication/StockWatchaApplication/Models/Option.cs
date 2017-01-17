namespace StockWatchApplication.Models
{
    using Contracts;
    using Enum;
    using Utils;

    public class Option : Derivative, IOption
    {
        public Option(string name, DataPoint currentDate, string underlying, OptionType type)
            : base(name, currentDate, underlying)
        {
            this.Underlying = underlying;
            this.Type = type;
        }

        public OptionType Type { get; protected set; }
    }
}
