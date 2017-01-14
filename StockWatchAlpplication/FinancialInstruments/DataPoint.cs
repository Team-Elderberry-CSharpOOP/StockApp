namespace FinancialInstruments
{
    using System;

    public struct DataPoint
    {
        public DataPoint(DateTime date, decimal price)
        {
            this.Date = date;
            this.Price = price;
        }

        public decimal Price { get; private set; }
        public DateTime Date { get; private set; }

    }
}
