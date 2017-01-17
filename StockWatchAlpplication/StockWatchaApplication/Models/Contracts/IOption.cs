namespace StockWatchApplication.Models.Contracts
{
    using Enum;

    public interface IOption : IFinancialInstrument, IDerivative
    {
        OptionType Type { get; }
    }
}
