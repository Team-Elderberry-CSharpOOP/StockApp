namespace Data
{
    using FinancialInstruments;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class DataProvider
    {
        const string headerIdentificator = "Date";
        const string dateFormat = "yyyy-MM-dd";
        const int dateColumn = 0;
        const int priceColumn = 6;
        const char delimitor = ',';
        const string tickerIdentifier = @"""t""";
        const string exchangeIdentifier = @"""e""";
        const string priceIdentifier = @"""l""";
        const string priceChangeIdentifier = @"""c""";
        const string percentagePriceChangeIdentifier = @"""cp""";
        const string dateIdentifier = @"""lt_dts""";
        const string doubleQuotes = @"""";

        public static Index ProvideIndexSeries(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            string file = GetData.ProvideDownloadedFile(ticker, startDate, endDate, frequency);
            var currentIndex = new Index(ticker, ReadDataSeries(file));
            return currentIndex;
        }

        public static List<Stock> ProvideStockPriceChanges()
        {
            string file = GetData.ProvideDownloadedFile();
            var stocks = ReadPriceChanges(file);
            return stocks;
        }

        //Read a data series - historical data
        private static List<DataPoint> ReadDataSeries(string file)
        {
            // reads the data from a csv file
            CultureInfo provider = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(File.OpenRead(file));
            var dataSeries = new List<DataPoint>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Contains(headerIdentificator)) continue; //skip the headers

                //take only the date and the adjusted close price. Create a new DataPoint
                var values = line.Split(delimitor);
                var date = DateTime.ParseExact(values[dateColumn], dateFormat, provider);
                var price = decimal.Parse(values[priceColumn]);
                DataPoint currentDataPoint = new DataPoint(date, price);

                //add the current DataPoint into the data series
                dataSeries.Add(currentDataPoint);
            };

            //remove the file
            reader.Close();
            File.Delete(file);

            //reorder data
            dataSeries.Reverse();
            return dataSeries;
        }

        //Read and provide the current price change
        private static List<Stock> ReadPriceChanges(string file)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(File.OpenRead(file));
            var allStocks = new List<Stock>();

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
                //Check if all the nessecary data is collected
                if (!string.IsNullOrEmpty(ticker) &&
                    !string.IsNullOrEmpty(exchange) &&
                    price != decimal.MinValue &&
                    priceChange != decimal.MinValue &&
                    percentagePriceChange != decimal.MinValue &&
                    date != default(DateTime))
                {
                    //having the full information we can create the stock
                    Stock currentStock = CreateStock(ticker, exchange, date, price, priceChange, percentagePriceChange);
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

        //Extracts the value corresponding to the identifier as string
        private static string ExtractValueFromString(string text, string identifier)
        {
            text = text.Substring(text.IndexOf(identifier) + identifier.Length + 1);
            int startIndex = text.IndexOf(doubleQuotes) + 1;
            int length = text.LastIndexOf(doubleQuotes) - startIndex;

            return text.Substring(startIndex, length);
        }

        //Given the collected data create a new Stock
        private static Stock CreateStock(string ticker, string exchange, DateTime date,
                                         decimal price, decimal priceChange, decimal percentagePriceChange)
        {
            DataPoint datePrice = new DataPoint(date, price);
            DataPoint datePriceChange = new DataPoint(date, priceChange);
            DataPoint datePercentagePriceChange = new DataPoint(date, percentagePriceChange);

            Stock currentStock = new Stock(ticker, datePrice, datePriceChange, datePercentagePriceChange, exchange);
            return currentStock;
        }
    }
}