namespace StockWatchApplication.Models
{
    using Contracts;
    using System;
    using Utils;

    public abstract class Derivative : FinancialInstrument, IDerivative
    {

        private const int MinUnderlyingLength = 3;
        private const int MaxUnderlyingLength = 20;
        private const string InvalidUnderlyingLengthExceptionMessage = "The underlying should be between 3 and 20 symbols long.";

        private string underlying;

        protected Derivative(string name, DataPoint currentDate, string underLying) : base(name, currentDate)
        {
            this.Underlying = underlying;
        }

        public string Underlying
        {
            get { return this.underlying; }
            protected set
            {
                if (value.Length < MinUnderlyingLength || value.Length > MaxUnderlyingLength)
                {
                    throw new ArgumentException(InvalidUnderlyingLengthExceptionMessage);
                }
                this.underlying = value;
            }
        }

    }
}
