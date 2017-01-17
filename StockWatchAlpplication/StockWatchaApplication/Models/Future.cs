namespace StockWatchApplication.Models
{
    using System;
    using Contracts;
    using Utils;

    public class Future : Derivative, IFuture
    {
        protected const string InvalidContractSizeExceptionMessage = "Contract size cannot be less or equal to zero";
        private long contractSize;

        public Future(string name, DataPoint currentPrice, long contractSize, string underlying) 
            : base(name, currentPrice, underlying)
        {
            this.ContractSize = contractSize;
        }

        public long ContractSize
        {
            get
            {
                return this.contractSize;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidContractSizeExceptionMessage);
                }
                this.contractSize = value;
            }
        }

    }
}
