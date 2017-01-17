namespace StockWatchApplication.Models
{
    using System;
    using Contracts;
    using Utils;

    public abstract class FinancialInstrument : IFinancialInstrument
    {
        private const string InvalidPriceExceptionMessage = "Invalid Price: Price cannot be less than zero";
        private DataPoint currentPrice;

        protected FinancialInstrument()
        {

        }

        protected FinancialInstrument(string name, DataPoint currentPrice)
        {
            this.Name = name;
            this.CurrentPrice = currentPrice;
            this.Risk = (decimal)Math.Sqrt((double)this.CurrentPrice.Price);
        }

        public DataPoint CurrentPrice
        {
            get
            {
                return this.currentPrice;
            }

            set
            {
                if (value.Price < 0)
                {
                    throw new ArgumentException(InvalidPriceExceptionMessage);
                }

                this.currentPrice = value;
            }
        }

        public string Name { get; protected set; }

        public decimal Risk { get; protected set; }
    }
}
