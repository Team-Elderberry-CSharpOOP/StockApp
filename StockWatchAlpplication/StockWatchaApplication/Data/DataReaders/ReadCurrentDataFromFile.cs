namespace StockWatchApplication.Data.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using Creators;
    using Models.Contracts;

    public static class ReadCurrentDataFromFile
    {
        const string tickerIdentifier = @"""t""";
        const string exchangeIdentifier = @"""e""";
        const string priceIdentifier = @"""l""";
        const string priceChangeIdentifier = @"""c""";
        const string percentagePriceChangeIdentifier = @"""cp""";
        const string dateIdentifier = @"""lt_dts""";
        const string doubleQuotes = @"""";

        //Read and provide the current price change
        internal static IList<IStock> ReadPriceChanges(string file)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(File.OpenRead(file));
            var allStocks = new List<IStock>();

            string ticker = null;
            string exchange = null;
            decimal price = decimal.MinValue;
            decimal priceChange = decimal.MinValue;
            decimal percentagePriceChange = decimal.MinValue;
            DateTime date = default(DateTime);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                #region Search For Identifiers
                if (line.Contains(tickerIdentifier))
                {
                    ticker = ExtractValueFromString(line, tickerIdentifier);
                }
                else if (line.Contains(exchangeIdentifier))
                {
                    exchange = ExtractValueFromString(line, exchangeIdentifier);
                }
                else if (line.Contains(dateIdentifier))
                {
                    string dateTimeAsString = ExtractValueFromString(line, dateIdentifier);
                    date = DateTime.Parse(dateTimeAsString, null, DateTimeStyles.RoundtripKind);
                }
                else if (line.Contains(priceIdentifier))
                {
                    string a = ExtractValueFromString(line, priceIdentifier);
                    price = decimal.Parse(a);
                }
                else if (line.Contains(priceChangeIdentifier))
                {
                    priceChange = decimal.Parse(ExtractValueFromString(line, priceChangeIdentifier));
                }
                else if (line.Contains(percentagePriceChangeIdentifier))
                {
                    percentagePriceChange = decimal.Parse(ExtractValueFromString(line, percentagePriceChangeIdentifier));
                }
                #endregion

                #region If all the data is collected
                //Check if all the necessary data is collected
                if (!string.IsNullOrEmpty(ticker) &&
                    !string.IsNullOrEmpty(exchange) &&
                    price != decimal.MinValue &&
                    priceChange != decimal.MinValue &&
                    percentagePriceChange != decimal.MinValue &&
                    date != default(DateTime))
                {
                    //having the full information we can create the stock
                    IStock currentStock = StockCreator.CreateStock
                        (ticker, exchange, date, price, priceChange, percentagePriceChange);
                    allStocks.Add(currentStock);

                    //clear the variables for the next stock
                    ticker = null;
                    exchange = null;
                    price = decimal.MinValue;
                    priceChange = decimal.MinValue;
                    percentagePriceChange = decimal.MinValue;
                }
                #endregion
            }

            reader.Close();
            File.Delete(file);
            return allStocks;
        }

        private static string ExtractValueFromString(string text, string identifier)
        {
            text = text.Substring(text.IndexOf(identifier) + identifier.Length + 1);
            int startIndex = text.IndexOf(doubleQuotes) + 1;
            int length = text.LastIndexOf(doubleQuotes) - startIndex;

            return text.Substring(startIndex, length);
        }
    }
}
